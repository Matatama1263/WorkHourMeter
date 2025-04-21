using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace WorkHourMeter
{
    public partial class MainForm : Form
    {
        #region Windows API
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        #endregion

        #region 저장용

        private string GetSaveFilePath()
        {
            // 로컬 애플리케이션 데이터 폴더에 저장
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(appDataPath, "WorkHourMeter");
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }
            return Path.Combine(appFolder, "Save.sv");
        }

        public struct Config
        {
            public bool saveOnExit;
            public TimeSpan quotas;
        }

        public struct SaveFile
        {
            public TimeSpan totalElapsedTime;
            public TimeSpan actualWorkTime;
            public List<string> trackingProcessNames;
        }

        public Config config;
        public SaveFile saveFile;
        #endregion

        #region 변수
        public List<string> trackingProcessNames;

        bool isTracking = false;
        bool isWorking = false;
        bool isChecking = false;

        TimeSpan totalElapsedTime = TimeSpan.Zero;
        TimeSpan actualWorkTime = TimeSpan.Zero;
        TimeSpan quotasTime = TimeSpan.Zero;
        TimeSpan remainingTime = TimeSpan.Zero;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            LoadConfigAndSaveFile();
            UpdateTimeLabelAndPer();
            trackingProcessNames = new List<string>();
            SetTrackingProcesses(saveFile.trackingProcessNames); // 초기화
        }

        #region 메소드
        private void LoadConfigAndSaveFile()
        {
            string saveFilePath = GetSaveFilePath();
            // 설정 파일 로드
            if (File.Exists(saveFilePath))
            {
                try
                {
                    using (var reader = new BinaryReader(File.OpenRead(saveFilePath)))
                    {
                        saveFile.totalElapsedTime = TimeSpan.FromTicks(reader.ReadInt64());
                        saveFile.actualWorkTime = TimeSpan.FromTicks(reader.ReadInt64());
                        int processCount = reader.ReadInt32();
                        saveFile.trackingProcessNames = new List<string>();
                        if (processCount != 0) // 추적할 프로세스가 없을 경우
                        {
                            for (int i = 0; i < processCount; i++)
                            {
                                saveFile.trackingProcessNames.Add(reader.ReadString());
                            }
                        }
                        
                        config.quotas = TimeSpan.FromTicks(reader.ReadInt64());
                        config.saveOnExit = reader.ReadBoolean();
                    }

                    quotasTime = config.quotas;
                    if (config.saveOnExit) // 저장된 시간 불러오기
                    {
                        totalElapsedTime = saveFile.totalElapsedTime;
                        actualWorkTime = saveFile.actualWorkTime;
                    }
                    else // 시간 초기화
                    {
                        totalElapsedTime = TimeSpan.Zero;
                        actualWorkTime = TimeSpan.Zero;
                    }
                }
                catch
                {
                    MessageBox.Show("세이브 파일을 읽는 중 오류가 발생했습니다. 새 파일을 생성합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CreateNewSaveFile();
                }
            }
            else // 설정 파일이 없을 경우
            {
                CreateNewSaveFile();
            }

            // 시간 라벨 설정
            TotalElapsedTimeLabel.Text = totalElapsedTime.ToString(@"hh\:mm\:ss");
            ActualWorkTimeLabel.Text = actualWorkTime.ToString(@"hh\:mm\:ss");
        }

        private void CreateNewSaveFile()
        {
            saveFile = new SaveFile { totalElapsedTime = TimeSpan.Zero, actualWorkTime = TimeSpan.Zero, trackingProcessNames = new List<string>() };
            config = new Config { quotas = TimeSpan.FromHours(6), saveOnExit = true };
            quotasTime = config.quotas;
        }
        

        void ResetTimer()
        {
            Timer.Stop();
            totalElapsedTime = TimeSpan.Zero;
            actualWorkTime = TimeSpan.Zero;
            isChecking = false;
            isWorking = false;

            TotalElapsedTimeLabel.Text = "00:00:00";
            ActualWorkTimeLabel.Text = "00:00:00";
            PercentageOfWork.Value = 0;
            PercentageOfQuotas.Value = 0;
            StartPauseButton.Text = "▶";

            UpdateTimeLabelAndPer();
        }

        private void UpdateTimeLabelAndPer()
        {
            PercentageOfWork.Value = totalElapsedTime.TotalMilliseconds > 0
                ? (int)(actualWorkTime.TotalMilliseconds / totalElapsedTime.TotalMilliseconds * 100)
                : 0;

            if (actualWorkTime >= quotasTime)
            {
                PercentageOfQuotas.Value = 100;
                QuotasLabel.Text = "할당량을 전부 채웠습니다!";
            }
            else
            {
                PercentageOfQuotas.Value = (int)(actualWorkTime.TotalMilliseconds / quotasTime.TotalMilliseconds * 100);
                remainingTime = quotasTime - actualWorkTime;
                // 24시간 초과 시 days도 포함해서 표시
                if (remainingTime.TotalHours >= 24)
                {
                    QuotasLabel.Text = $"완료까지 {(int)remainingTime.TotalDays}일 {remainingTime:hh\\:mm\\:ss} 남았습니다.";
                }
                else
                    // 24시간 미만일 경우
                    QuotasLabel.Text = $"완료까지 {remainingTime:hh\\:mm\\:ss} 남았습니다.";
            }
        }

        // 추적중인 프로세스가 포커스 상태인지 확인
        private bool IsAnyTrackingProcessFocused()
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            if (foregroundWindow == IntPtr.Zero) return false;

            GetWindowThreadProcessId(foregroundWindow, out uint foregroundProcessId);
            Process foregroundProcess = Process.GetProcessById((int)foregroundProcessId);

            return trackingProcessNames.Contains(foregroundProcess.ProcessName);
        }

        // 추적할 프로세스를 설정
        public void SetTrackingProcesses(List<string> trackingProcesses)
        {
            trackingProcessNames.Clear();
            trackingProcessNames.AddRange(trackingProcesses.Select(p => p));

            isTracking = this.trackingProcessNames.Count > 0;
            label5.Text = isTracking
                ? string.Join("\n", trackingProcessNames)
                : "추적할 프로세스를 선택하세요.";
        }
        #endregion

        #region 이벤트 핸들러
        private void ChangeTrackingProcess_Click(object sender, EventArgs e)
        {
            using (TrackingProcessForm trackingProcessForm = new TrackingProcessForm(this))
            {
                trackingProcessForm.ShowDialog();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("타이머를 초기화 하시겠습니까?", "초기화", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            ResetTimer();
        }

        private void StartPauseButton_Click(object sender, EventArgs e)
        {
            if (!isChecking)
            {
                if (!isTracking)
                {
                    MessageBox.Show("추적할 프로세스를 선택하세요.");
                    return;
                }

                Timer.Start();
                isChecking = true;
            }

            if (isTracking)
            {
                isWorking = !isWorking;
                StartPauseButton.Text = isWorking ? "||" : "▶";
            }
            else
            {
                MessageBox.Show("추적할 프로세스를 선택하세요.");
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm(this))
            {
                settingsForm.ShowDialog();
                quotasTime = config.quotas;
                UpdateTimeLabelAndPer();
            }
        }

        private void Timer_Tick(object sender, EventArgs e) //interval 100
        {
            totalElapsedTime += TimeSpan.FromMilliseconds(100);
            //24시간 초과 시 days도 포함해서 표시
            if (totalElapsedTime.TotalHours >= 24)
            {
                TotalElapsedTimeLabel.Text = $"{(int)totalElapsedTime.TotalDays}일 {totalElapsedTime:hh\\:mm\\:ss}";
            }
            else TotalElapsedTimeLabel.Text = totalElapsedTime.ToString(@"hh\:mm\:ss");

            if (isWorking && IsAnyTrackingProcessFocused())
            {
                actualWorkTime += TimeSpan.FromMilliseconds(100);
                // 24시간 초과 시 days도 포함해서 표시
                if (actualWorkTime.TotalHours >= 24)
                {
                    ActualWorkTimeLabel.Text = $"{(int)actualWorkTime.TotalDays}일 {actualWorkTime:hh\\:mm\\:ss}";
                }
                else ActualWorkTimeLabel.Text = actualWorkTime.ToString(@"hh\:mm\:ss");
            }

            UpdateTimeLabelAndPer();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string saveFilePath = GetSaveFilePath();

            if (config.saveOnExit)
            {
                saveFile.totalElapsedTime = totalElapsedTime;
                saveFile.actualWorkTime = actualWorkTime;
                saveFile.trackingProcessNames = trackingProcessNames;
            }

            using (var writer = new BinaryWriter(File.Open(saveFilePath, FileMode.Create)))
            {
                writer.Write(saveFile.totalElapsedTime.Ticks);
                writer.Write(saveFile.actualWorkTime.Ticks);
                if (saveFile.trackingProcessNames.Count != 0)
                {
                    writer.Write(saveFile.trackingProcessNames.Count);
                    foreach (string processName in saveFile.trackingProcessNames)
                    {
                        writer.Write(processName);
                    }
                }
                else
                {
                    writer.Write(0);
                }

                writer.Write(config.quotas.Ticks);
                writer.Write(config.saveOnExit);
            }
        }
        #endregion
    }
}
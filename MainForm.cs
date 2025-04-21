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

        #region �����

        private string GetSaveFilePath()
        {
            // ���� ���ø����̼� ������ ������ ����
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

        #region ����
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
            SetTrackingProcesses(saveFile.trackingProcessNames); // �ʱ�ȭ
        }

        #region �޼ҵ�
        private void LoadConfigAndSaveFile()
        {
            string saveFilePath = GetSaveFilePath();
            // ���� ���� �ε�
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
                        if (processCount != 0) // ������ ���μ����� ���� ���
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
                    if (config.saveOnExit) // ����� �ð� �ҷ�����
                    {
                        totalElapsedTime = saveFile.totalElapsedTime;
                        actualWorkTime = saveFile.actualWorkTime;
                    }
                    else // �ð� �ʱ�ȭ
                    {
                        totalElapsedTime = TimeSpan.Zero;
                        actualWorkTime = TimeSpan.Zero;
                    }
                }
                catch
                {
                    MessageBox.Show("���̺� ������ �д� �� ������ �߻��߽��ϴ�. �� ������ �����մϴ�.", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CreateNewSaveFile();
                }
            }
            else // ���� ������ ���� ���
            {
                CreateNewSaveFile();
            }

            // �ð� �� ����
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
            StartPauseButton.Text = "��";

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
                QuotasLabel.Text = "�Ҵ緮�� ���� ä�����ϴ�!";
            }
            else
            {
                PercentageOfQuotas.Value = (int)(actualWorkTime.TotalMilliseconds / quotasTime.TotalMilliseconds * 100);
                remainingTime = quotasTime - actualWorkTime;
                // 24�ð� �ʰ� �� days�� �����ؼ� ǥ��
                if (remainingTime.TotalHours >= 24)
                {
                    QuotasLabel.Text = $"�Ϸ���� {(int)remainingTime.TotalDays}�� {remainingTime:hh\\:mm\\:ss} ���ҽ��ϴ�.";
                }
                else
                    // 24�ð� �̸��� ���
                    QuotasLabel.Text = $"�Ϸ���� {remainingTime:hh\\:mm\\:ss} ���ҽ��ϴ�.";
            }
        }

        // �������� ���μ����� ��Ŀ�� �������� Ȯ��
        private bool IsAnyTrackingProcessFocused()
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            if (foregroundWindow == IntPtr.Zero) return false;

            GetWindowThreadProcessId(foregroundWindow, out uint foregroundProcessId);
            Process foregroundProcess = Process.GetProcessById((int)foregroundProcessId);

            return trackingProcessNames.Contains(foregroundProcess.ProcessName);
        }

        // ������ ���μ����� ����
        public void SetTrackingProcesses(List<string> trackingProcesses)
        {
            trackingProcessNames.Clear();
            trackingProcessNames.AddRange(trackingProcesses.Select(p => p));

            isTracking = this.trackingProcessNames.Count > 0;
            label5.Text = isTracking
                ? string.Join("\n", trackingProcessNames)
                : "������ ���μ����� �����ϼ���.";
        }
        #endregion

        #region �̺�Ʈ �ڵ鷯
        private void ChangeTrackingProcess_Click(object sender, EventArgs e)
        {
            using (TrackingProcessForm trackingProcessForm = new TrackingProcessForm(this))
            {
                trackingProcessForm.ShowDialog();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ÿ�̸Ӹ� �ʱ�ȭ �Ͻðڽ��ϱ�?", "�ʱ�ȭ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                    MessageBox.Show("������ ���μ����� �����ϼ���.");
                    return;
                }

                Timer.Start();
                isChecking = true;
            }

            if (isTracking)
            {
                isWorking = !isWorking;
                StartPauseButton.Text = isWorking ? "||" : "��";
            }
            else
            {
                MessageBox.Show("������ ���μ����� �����ϼ���.");
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
            //24�ð� �ʰ� �� days�� �����ؼ� ǥ��
            if (totalElapsedTime.TotalHours >= 24)
            {
                TotalElapsedTimeLabel.Text = $"{(int)totalElapsedTime.TotalDays}�� {totalElapsedTime:hh\\:mm\\:ss}";
            }
            else TotalElapsedTimeLabel.Text = totalElapsedTime.ToString(@"hh\:mm\:ss");

            if (isWorking && IsAnyTrackingProcessFocused())
            {
                actualWorkTime += TimeSpan.FromMilliseconds(100);
                // 24�ð� �ʰ� �� days�� �����ؼ� ǥ��
                if (actualWorkTime.TotalHours >= 24)
                {
                    ActualWorkTimeLabel.Text = $"{(int)actualWorkTime.TotalDays}�� {actualWorkTime:hh\\:mm\\:ss}";
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
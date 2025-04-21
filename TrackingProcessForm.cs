using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WorkHourMeter
{
    public partial class TrackingProcessForm : Form
    {
        public MainForm mainForm;
        public List<string> trackingProcesses;
        public List<string> notTrackingProcesses;
        public TrackingProcessForm(MainForm mainForm)
        {
            InitializeComponent();
            trackingProcesses = new List<string>();
            notTrackingProcesses = new List<string>();
            this.mainForm = mainForm;

            trackingProcesses.AddRange(mainForm.trackingProcessNames.Select(p => p));

            // 프로세스 목록을 가져와서 ListBox에 추가
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                // 윈도우가 없는 프로세스는 제외
                if (process.MainWindowHandle == IntPtr.Zero)
                    continue;

                // 프로세스 이름을 가져옴
                string processName = process.ProcessName;
                // 프로세스 이름이 이미 있는지 확인
                if (trackingProcesses.Contains(processName) || notTrackingProcesses.Contains(processName))
                    continue;
                // 프로세스 이름을 NotTrackingProcesses에 추가
                notTrackingProcesses.Add(processName);
            }
            // 두 리스트를 이름순으로 정렬
            trackingProcesses = trackingProcesses.OrderBy(p => p).ToList();
            notTrackingProcesses = notTrackingProcesses.OrderBy(p => p).ToList();
            // ListBox에 프로세스 이름 추가
            foreach (string process in trackingProcesses)
            {
                TrackingProcessListBox.Items.Add(process);
            }
            foreach (string process in notTrackingProcesses)
            {
                NotTrackingProcessListBox.Items.Add(process);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            // 선택된 프로세스를 TrackingProcesses에 추가
            if (NotTrackingProcessListBox.SelectedItem != null)
            {
                string selectedProcess = NotTrackingProcessListBox.SelectedItem.ToString();
                notTrackingProcesses.Remove(selectedProcess);
                trackingProcesses.Add(selectedProcess);
                TrackingProcessListBox.Items.Add(selectedProcess);
                NotTrackingProcessListBox.Items.Remove(selectedProcess);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // 선택된 프로세스를 NotTrackingProcesses에 추가
            if (TrackingProcessListBox.SelectedItem != null)
            {
                string selectedProcess = TrackingProcessListBox.SelectedItem.ToString();
                trackingProcesses.Remove(selectedProcess);
                notTrackingProcesses.Add(selectedProcess);
                NotTrackingProcessListBox.Items.Add(selectedProcess);
                TrackingProcessListBox.Items.Remove(selectedProcess);
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            // 선택된 프로세스를 MainForm에 전달
            mainForm.SetTrackingProcesses(trackingProcesses);
            this.Close();
        }
    }
}

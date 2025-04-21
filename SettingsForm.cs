using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WorkHourMeter
{
    public partial class SettingsForm : Form
    {
        MainForm mainForm;
        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            // 설정 파일 로드
            quotaHoursTextBox.Text = mainForm.config.quotas.Hours.ToString();
            quotaMinutesTextBox.Text = mainForm.config.quotas.Minutes.ToString();
            SaveOnExit.Checked = mainForm.config.saveOnExit;
        }

        private void SaveOnExit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SaveOnExit, "프로그램이 종료될 때 작업 시간이 저장됩니다.");
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            mainForm.config.saveOnExit = SaveOnExit.Checked;

            if (string.IsNullOrEmpty(quotaHoursTextBox.Text))
            {
                quotaHoursTextBox.Text = "0";
            }
            if (string.IsNullOrEmpty(quotaMinutesTextBox.Text))
            {
                quotaMinutesTextBox.Text = "0";
            }

            int hours = int.Parse(quotaHoursTextBox.Text);
            int minutes = int.Parse(quotaMinutesTextBox.Text);

            // 24시간 이상일 경우 days와 remainingHours로 분리
            int days = hours / 24;
            int remainingHours = hours % 24;

            // TimeSpan 생성
            mainForm.config.quotas = new TimeSpan(days, remainingHours, minutes, 0);
            this.Close();
        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 허용
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // 입력 무시
            }
        }

        private void quotaHoursTextBox_TextChanged(object sender, EventArgs e)
        {
            // 99가 넘는 값은 허용하지 않음
            if (int.TryParse(quotaHoursTextBox.Text, out int value) && value > 99)
            {
                quotaHoursTextBox.Text = "99";
                quotaHoursTextBox.SelectionStart = quotaHoursTextBox.Text.Length; // 커서를 끝으로 이동
            }
        }

        private void quotaMinutesTextBox_TextChanged(object sender, EventArgs e)
        {
            // 59가 넘는 값은 허용하지 않음
            if (int.TryParse(quotaMinutesTextBox.Text, out int value) && value > 59)
            {
                quotaMinutesTextBox.Text = "59";
                quotaMinutesTextBox.SelectionStart = quotaMinutesTextBox.Text.Length; // 커서를 끝으로 이동
            }
        }
    }
}

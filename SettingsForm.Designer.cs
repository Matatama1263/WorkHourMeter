namespace WorkHourMeter
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            SaveOnExit = new CheckBox();
            toolTip1 = new ToolTip(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            quotaHoursTextBox = new TextBox();
            quotaMinutesTextBox = new TextBox();
            Confirm = new Button();
            SuspendLayout();
            // 
            // SaveOnExit
            // 
            SaveOnExit.AutoSize = true;
            SaveOnExit.Location = new Point(12, 12);
            SaveOnExit.Name = "SaveOnExit";
            SaveOnExit.Size = new Size(106, 19);
            SaveOnExit.TabIndex = 0;
            SaveOnExit.Text = "작업 시간 저장";
            SaveOnExit.UseVisualStyleBackColor = true;
            SaveOnExit.MouseHover += SaveOnExit_MouseHover;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 64);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "할당량";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 85);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 2;
            label2.Text = "시간";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(142, 85);
            label3.Name = "label3";
            label3.Size = new Size(19, 15);
            label3.TabIndex = 3;
            label3.Text = "분";
            // 
            // quotaHoursTextBox
            // 
            quotaHoursTextBox.Location = new Point(17, 82);
            quotaHoursTextBox.Name = "quotaHoursTextBox";
            quotaHoursTextBox.Size = new Size(38, 23);
            quotaHoursTextBox.TabIndex = 4;
            quotaHoursTextBox.TextChanged += quotaHoursTextBox_TextChanged;
            quotaHoursTextBox.KeyPress += NumericTextBox_KeyPress;
            // 
            // quotaMinutesTextBox
            // 
            quotaMinutesTextBox.Location = new Point(98, 82);
            quotaMinutesTextBox.Name = "quotaMinutesTextBox";
            quotaMinutesTextBox.Size = new Size(38, 23);
            quotaMinutesTextBox.TabIndex = 5;
            quotaMinutesTextBox.TextChanged += quotaMinutesTextBox_TextChanged;
            quotaMinutesTextBox.KeyPress += NumericTextBox_KeyPress;
            // 
            // Confirm
            // 
            Confirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Confirm.Cursor = Cursors.Hand;
            Confirm.Location = new Point(130, 119);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(75, 23);
            Confirm.TabIndex = 6;
            Confirm.Text = "확인";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += Confirm_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(217, 154);
            Controls.Add(Confirm);
            Controls.Add(quotaMinutesTextBox);
            Controls.Add(quotaHoursTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveOnExit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox SaveOnExit;
        private ToolTip toolTip1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox quotaHoursTextBox;
        private TextBox quotaMinutesTextBox;
        private Button Confirm;
    }
}
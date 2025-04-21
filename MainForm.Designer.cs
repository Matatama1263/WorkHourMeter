namespace WorkHourMeter
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            QuotasLabel = new Label();
            PercentageOfQuotas = new ProgressBar();
            label6 = new Label();
            ResetButton = new Button();
            label4 = new Label();
            PercentageOfWork = new ProgressBar();
            ActualWorkTimeLabel = new Label();
            StartPauseButton = new Button();
            TotalElapsedTimeLabel = new Label();
            groupBox1 = new GroupBox();
            label5 = new Label();
            ChangeTrackingProcessButton = new Button();
            Timer = new System.Windows.Forms.Timer(components);
            SettingsButton = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(215, 37);
            label1.TabIndex = 0;
            label1.Text = "작업시간 측정기";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(104, 40);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 1;
            label2.Text = "총 경과 시간";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(92, 92);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 2;
            label3.Text = "실제 작업 시간";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(QuotasLabel);
            panel1.Controls.Add(PercentageOfQuotas);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(ResetButton);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(PercentageOfWork);
            panel1.Controls.Add(ActualWorkTimeLabel);
            panel1.Controls.Add(StartPauseButton);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(TotalElapsedTimeLabel);
            panel1.Location = new Point(272, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 250);
            panel1.TabIndex = 3;
            // 
            // QuotasLabel
            // 
            QuotasLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            QuotasLabel.AutoSize = true;
            QuotasLabel.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            QuotasLabel.Location = new Point(12, 222);
            QuotasLabel.Name = "QuotasLabel";
            QuotasLabel.Size = new Size(156, 13);
            QuotasLabel.TabIndex = 11;
            QuotasLabel.Text = "완료까지 00:00:00 남았습니다.";
            // 
            // PercentageOfQuotas
            // 
            PercentageOfQuotas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PercentageOfQuotas.Location = new Point(32, 181);
            PercentageOfQuotas.Name = "PercentageOfQuotas";
            PercentageOfQuotas.Size = new Size(165, 23);
            PercentageOfQuotas.TabIndex = 10;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(154, 207);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 9;
            label6.Text = "할당량";
            // 
            // ResetButton
            // 
            ResetButton.Cursor = Cursors.Hand;
            ResetButton.Location = new Point(3, 49);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(40, 40);
            ResetButton.TabIndex = 8;
            ResetButton.Text = "■";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(138, 154);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 7;
            label4.Text = "시간 비율";
            // 
            // PercentageOfWork
            // 
            PercentageOfWork.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PercentageOfWork.Location = new Point(32, 128);
            PercentageOfWork.Name = "PercentageOfWork";
            PercentageOfWork.Size = new Size(165, 23);
            PercentageOfWork.TabIndex = 6;
            // 
            // ActualWorkTimeLabel
            // 
            ActualWorkTimeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ActualWorkTimeLabel.AutoSize = true;
            ActualWorkTimeLabel.Font = new Font("맑은 고딕", 20F);
            ActualWorkTimeLabel.Location = new Point(60, 55);
            ActualWorkTimeLabel.Name = "ActualWorkTimeLabel";
            ActualWorkTimeLabel.Size = new Size(119, 37);
            ActualWorkTimeLabel.TabIndex = 4;
            ActualWorkTimeLabel.Text = "00:00:00";
            // 
            // StartPauseButton
            // 
            StartPauseButton.Cursor = Cursors.Hand;
            StartPauseButton.Location = new Point(3, 3);
            StartPauseButton.Name = "StartPauseButton";
            StartPauseButton.Size = new Size(40, 40);
            StartPauseButton.TabIndex = 5;
            StartPauseButton.Text = "▶";
            StartPauseButton.UseVisualStyleBackColor = true;
            StartPauseButton.Click += StartPauseButton_Click;
            // 
            // TotalElapsedTimeLabel
            // 
            TotalElapsedTimeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TotalElapsedTimeLabel.AutoSize = true;
            TotalElapsedTimeLabel.Font = new Font("맑은 고딕", 20F);
            TotalElapsedTimeLabel.Location = new Point(60, 3);
            TotalElapsedTimeLabel.Name = "TotalElapsedTimeLabel";
            TotalElapsedTimeLabel.Size = new Size(119, 37);
            TotalElapsedTimeLabel.TabIndex = 3;
            TotalElapsedTimeLabel.Text = "00:00:00";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(ChangeTrackingProcessButton);
            groupBox1.Location = new Point(12, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 219);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "추적중인 프로세스";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label5.Location = new Point(6, 54);
            label5.Name = "label5";
            label5.Size = new Size(160, 13);
            label5.TabIndex = 5;
            label5.Text = "추적할 프로세스를 선택하세요.";
            // 
            // ChangeTrackingProcessButton
            // 
            ChangeTrackingProcessButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ChangeTrackingProcessButton.Cursor = Cursors.Hand;
            ChangeTrackingProcessButton.Location = new Point(119, 22);
            ChangeTrackingProcessButton.Name = "ChangeTrackingProcessButton";
            ChangeTrackingProcessButton.Size = new Size(75, 23);
            ChangeTrackingProcessButton.TabIndex = 6;
            ChangeTrackingProcessButton.Text = "편집";
            ChangeTrackingProcessButton.UseVisualStyleBackColor = true;
            ChangeTrackingProcessButton.Click += ChangeTrackingProcess_Click;
            // 
            // Timer
            // 
            Timer.Tick += Timer_Tick;
            // 
            // SettingsButton
            // 
            SettingsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SettingsButton.Location = new Point(427, 2);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(45, 23);
            SettingsButton.TabIndex = 5;
            SettingsButton.Text = "설정";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 291);
            Controls.Add(SettingsButton);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(500, 330);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkHourMeter";
            FormClosing += MainForm_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Label TotalElapsedTimeLabel;
        private Label ActualWorkTimeLabel;
        private Button StartPauseButton;
        private ProgressBar PercentageOfWork;
        private Label label4;
        private GroupBox groupBox1;
        private Label label5;
        private Button ChangeTrackingProcessButton;
        private Button ResetButton;
        private System.Windows.Forms.Timer Timer;
        private Label QuotasLabel;
        private ProgressBar PercentageOfQuotas;
        private Label label6;
        private Button SettingsButton;
    }
}

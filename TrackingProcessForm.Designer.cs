namespace WorkHourMeter
{
    partial class TrackingProcessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackingProcessForm));
            TrackingProcessListBox = new ListBox();
            NotTrackingProcessListBox = new ListBox();
            Confirm = new Button();
            Add = new Button();
            Delete = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // TrackingProcessListBox
            // 
            TrackingProcessListBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TrackingProcessListBox.FormattingEnabled = true;
            TrackingProcessListBox.ItemHeight = 15;
            TrackingProcessListBox.Location = new Point(216, 51);
            TrackingProcessListBox.Name = "TrackingProcessListBox";
            TrackingProcessListBox.Size = new Size(146, 169);
            TrackingProcessListBox.TabIndex = 0;
            // 
            // NotTrackingProcessListBox
            // 
            NotTrackingProcessListBox.FormattingEnabled = true;
            NotTrackingProcessListBox.ItemHeight = 15;
            NotTrackingProcessListBox.Location = new Point(12, 51);
            NotTrackingProcessListBox.Name = "NotTrackingProcessListBox";
            NotTrackingProcessListBox.Size = new Size(146, 169);
            NotTrackingProcessListBox.TabIndex = 1;
            // 
            // Confirm
            // 
            Confirm.Cursor = Cursors.Hand;
            Confirm.Location = new Point(164, 190);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(45, 30);
            Confirm.TabIndex = 2;
            Confirm.Text = "확정";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += Confirm_Click;
            // 
            // Add
            // 
            Add.Cursor = Cursors.Hand;
            Add.Location = new Point(165, 51);
            Add.Name = "Add";
            Add.Size = new Size(45, 30);
            Add.TabIndex = 3;
            Add.Text = ">";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Delete
            // 
            Delete.Cursor = Cursors.Hand;
            Delete.Location = new Point(164, 87);
            Delete.Name = "Delete";
            Delete.Size = new Size(45, 30);
            Delete.TabIndex = 4;
            Delete.Text = "<";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(135, 15);
            label1.TabIndex = 5;
            label1.Text = "추적중이 아닌 프로세스";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(216, 21);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 6;
            label2.Text = "추적중인 프로세스";
            // 
            // TrackingProcessForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(374, 232);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Delete);
            Controls.Add(Add);
            Controls.Add(Confirm);
            Controls.Add(NotTrackingProcessListBox);
            Controls.Add(TrackingProcessListBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(390, 271);
            Name = "TrackingProcessForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TrackingProcessForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox TrackingProcessListBox;
        private ListBox NotTrackingProcessListBox;
        private Button Confirm;
        private Button Add;
        private Button Delete;
        private Label label1;
        private Label label2;
    }
}
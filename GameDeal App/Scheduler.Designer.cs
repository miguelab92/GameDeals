namespace GameDeal_App
{
    partial class Scheduler
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
            this.components = new System.ComponentModel.Container();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.startupButton = new System.Windows.Forms.RadioButton();
            this.timedButton = new System.Windows.Forms.RadioButton();
            this.recommendLabel = new System.Windows.Forms.Label();
            this.scheduleWarningLabel = new System.Windows.Forms.Label();
            this.timeButtonAM = new System.Windows.Forms.RadioButton();
            this.timeButtonPM = new System.Windows.Forms.RadioButton();
            this.timeFormatLabel = new System.Windows.Forms.Label();
            this.deleteScheduleButton = new System.Windows.Forms.Button();
            this.timeInputBox = new System.Windows.Forms.MaskedTextBox();
            this.timeGroup = new System.Windows.Forms.GroupBox();
            this.taskExistsLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.successLabel = new System.Windows.Forms.Label();
            this.deleteErrorLabel = new System.Windows.Forms.Label();
            this.invalidTimeLabel = new System.Windows.Forms.Label();
            this.timeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduleButton
            // 
            this.scheduleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scheduleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleButton.Location = new System.Drawing.Point(20, 112);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(119, 27);
            this.scheduleButton.TabIndex = 6;
            this.scheduleButton.Text = "Save Schedule";
            this.toolTip.SetToolTip(this.scheduleButton, "Creates a scheduled task using above settings");
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // startupButton
            // 
            this.startupButton.AutoSize = true;
            this.startupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startupButton.Location = new System.Drawing.Point(12, 12);
            this.startupButton.Name = "startupButton";
            this.startupButton.Size = new System.Drawing.Size(145, 20);
            this.startupButton.TabIndex = 1;
            this.startupButton.TabStop = true;
            this.startupButton.Text = "On computer startup";
            this.startupButton.UseVisualStyleBackColor = true;
            // 
            // timedButton
            // 
            this.timedButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timedButton.AutoSize = true;
            this.timedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timedButton.Location = new System.Drawing.Point(12, 61);
            this.timedButton.Name = "timedButton";
            this.timedButton.Size = new System.Drawing.Size(132, 20);
            this.timedButton.TabIndex = 2;
            this.timedButton.TabStop = true;
            this.timedButton.Text = "At scheduled time";
            this.toolTip.SetToolTip(this.timedButton, "Warning: Computer must be on at scheduled time in order for app to function!");
            this.timedButton.UseVisualStyleBackColor = true;
            this.timedButton.CheckedChanged += new System.EventHandler(this.timedButton_CheckedChanged);
            // 
            // recommendLabel
            // 
            this.recommendLabel.AutoSize = true;
            this.recommendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recommendLabel.ForeColor = System.Drawing.Color.Green;
            this.recommendLabel.Location = new System.Drawing.Point(31, 30);
            this.recommendLabel.Name = "recommendLabel";
            this.recommendLabel.Size = new System.Drawing.Size(68, 12);
            this.recommendLabel.TabIndex = 3;
            this.recommendLabel.Text = "Recommended";
            // 
            // scheduleWarningLabel
            // 
            this.scheduleWarningLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scheduleWarningLabel.AutoSize = true;
            this.scheduleWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleWarningLabel.ForeColor = System.Drawing.Color.Olive;
            this.scheduleWarningLabel.Location = new System.Drawing.Point(31, 79);
            this.scheduleWarningLabel.Name = "scheduleWarningLabel";
            this.scheduleWarningLabel.Size = new System.Drawing.Size(101, 12);
            this.scheduleWarningLabel.TabIndex = 4;
            this.scheduleWarningLabel.Text = "Computer must stay on";
            this.scheduleWarningLabel.Visible = false;
            // 
            // timeButtonAM
            // 
            this.timeButtonAM.AutoSize = true;
            this.timeButtonAM.Enabled = false;
            this.timeButtonAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeButtonAM.Location = new System.Drawing.Point(6, 11);
            this.timeButtonAM.Name = "timeButtonAM";
            this.timeButtonAM.Size = new System.Drawing.Size(39, 16);
            this.timeButtonAM.TabIndex = 4;
            this.timeButtonAM.TabStop = true;
            this.timeButtonAM.Text = "AM";
            this.timeButtonAM.UseVisualStyleBackColor = true;
            // 
            // timeButtonPM
            // 
            this.timeButtonPM.AutoSize = true;
            this.timeButtonPM.Enabled = false;
            this.timeButtonPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeButtonPM.Location = new System.Drawing.Point(6, 29);
            this.timeButtonPM.Name = "timeButtonPM";
            this.timeButtonPM.Size = new System.Drawing.Size(38, 16);
            this.timeButtonPM.TabIndex = 5;
            this.timeButtonPM.TabStop = true;
            this.timeButtonPM.Text = "PM";
            this.timeButtonPM.UseVisualStyleBackColor = true;
            // 
            // timeFormatLabel
            // 
            this.timeFormatLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeFormatLabel.AutoSize = true;
            this.timeFormatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeFormatLabel.Location = new System.Drawing.Point(170, 55);
            this.timeFormatLabel.Name = "timeFormatLabel";
            this.timeFormatLabel.Size = new System.Drawing.Size(40, 12);
            this.timeFormatLabel.TabIndex = 9;
            this.timeFormatLabel.Text = "HH:MM";
            this.timeFormatLabel.Visible = false;
            // 
            // deleteScheduleButton
            // 
            this.deleteScheduleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteScheduleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteScheduleButton.Location = new System.Drawing.Point(162, 112);
            this.deleteScheduleButton.Name = "deleteScheduleButton";
            this.deleteScheduleButton.Size = new System.Drawing.Size(119, 27);
            this.deleteScheduleButton.TabIndex = 7;
            this.deleteScheduleButton.Text = "Delete Schedule";
            this.toolTip.SetToolTip(this.deleteScheduleButton, "Deletes scheduled task for this app if one exists");
            this.deleteScheduleButton.UseVisualStyleBackColor = true;
            this.deleteScheduleButton.Click += new System.EventHandler(this.deleteScheduleButton_Click);
            // 
            // timeInputBox
            // 
            this.timeInputBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeInputBox.Enabled = false;
            this.timeInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInputBox.Location = new System.Drawing.Point(162, 70);
            this.timeInputBox.Name = "timeInputBox";
            this.timeInputBox.Size = new System.Drawing.Size(57, 21);
            this.timeInputBox.TabIndex = 3;
            this.timeInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timeInputBox.Visible = false;
            this.timeInputBox.Enter += new System.EventHandler(this.timeInputBox_Enter);
            this.timeInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timeInputBox_KeyPress);
            this.timeInputBox.Leave += new System.EventHandler(this.timeInputBox_Leave);
            // 
            // timeGroup
            // 
            this.timeGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeGroup.Controls.Add(this.timeButtonAM);
            this.timeGroup.Controls.Add(this.timeButtonPM);
            this.timeGroup.Location = new System.Drawing.Point(237, 49);
            this.timeGroup.Name = "timeGroup";
            this.timeGroup.Size = new System.Drawing.Size(47, 51);
            this.timeGroup.TabIndex = 13;
            this.timeGroup.TabStop = false;
            this.timeGroup.Visible = false;
            // 
            // taskExistsLabel
            // 
            this.taskExistsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.taskExistsLabel.BackColor = System.Drawing.Color.Red;
            this.taskExistsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taskExistsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskExistsLabel.ForeColor = System.Drawing.Color.Red;
            this.taskExistsLabel.Location = new System.Drawing.Point(268, 9);
            this.taskExistsLabel.Name = "taskExistsLabel";
            this.taskExistsLabel.Size = new System.Drawing.Size(16, 16);
            this.taskExistsLabel.TabIndex = 15;
            this.toolTip.SetToolTip(this.taskExistsLabel, "Color shows if schedule currently exists. (Red = No schedule, Green = Schedule Ex" +
        "ists).");
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.successLabel.ForeColor = System.Drawing.Color.Green;
            this.successLabel.Location = new System.Drawing.Point(220, 11);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(44, 12);
            this.successLabel.TabIndex = 16;
            this.successLabel.Text = "Success!";
            this.successLabel.Visible = false;
            this.successLabel.Leave += new System.EventHandler(this.successLabel_Leave);
            // 
            // deleteErrorLabel
            // 
            this.deleteErrorLabel.AutoSize = true;
            this.deleteErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.deleteErrorLabel.Location = new System.Drawing.Point(171, 11);
            this.deleteErrorLabel.Name = "deleteErrorLabel";
            this.deleteErrorLabel.Size = new System.Drawing.Size(93, 12);
            this.deleteErrorLabel.TabIndex = 17;
            this.deleteErrorLabel.Text = "No schedule to delete";
            this.deleteErrorLabel.Visible = false;
            this.deleteErrorLabel.Leave += new System.EventHandler(this.deleteErrorLabel_Leave);
            // 
            // invalidTimeLabel
            // 
            this.invalidTimeLabel.AutoSize = true;
            this.invalidTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invalidTimeLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidTimeLabel.Location = new System.Drawing.Point(209, 11);
            this.invalidTimeLabel.Name = "invalidTimeLabel";
            this.invalidTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.invalidTimeLabel.TabIndex = 18;
            this.invalidTimeLabel.Text = "Invalid time";
            this.invalidTimeLabel.Visible = false;
            this.invalidTimeLabel.Leave += new System.EventHandler(this.invalidTimeLabel_Leave);
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 156);
            this.Controls.Add(this.invalidTimeLabel);
            this.Controls.Add(this.deleteErrorLabel);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.taskExistsLabel);
            this.Controls.Add(this.timeGroup);
            this.Controls.Add(this.timeInputBox);
            this.Controls.Add(this.deleteScheduleButton);
            this.Controls.Add(this.timeFormatLabel);
            this.Controls.Add(this.scheduleWarningLabel);
            this.Controls.Add(this.recommendLabel);
            this.Controls.Add(this.timedButton);
            this.Controls.Add(this.startupButton);
            this.Controls.Add(this.scheduleButton);
            this.MaximumSize = new System.Drawing.Size(308, 1080);
            this.MinimumSize = new System.Drawing.Size(308, 187);
            this.Name = "Scheduler";
            this.Text = "Scheduler";
            this.Load += new System.EventHandler(this.Scheduler_Load);
            this.timeGroup.ResumeLayout(false);
            this.timeGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.RadioButton startupButton;
        private System.Windows.Forms.RadioButton timedButton;
        private System.Windows.Forms.Label recommendLabel;
        private System.Windows.Forms.Label scheduleWarningLabel;
        private System.Windows.Forms.RadioButton timeButtonAM;
        private System.Windows.Forms.RadioButton timeButtonPM;
        private System.Windows.Forms.Label timeFormatLabel;
        private System.Windows.Forms.Button deleteScheduleButton;
        private System.Windows.Forms.MaskedTextBox timeInputBox;
        private System.Windows.Forms.GroupBox timeGroup;
        private System.Windows.Forms.Label taskExistsLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label successLabel;
        private System.Windows.Forms.Label deleteErrorLabel;
        private System.Windows.Forms.Label invalidTimeLabel;
    }
}
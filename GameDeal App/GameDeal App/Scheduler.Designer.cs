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
            this.ScheduleWarningLabel = new System.Windows.Forms.Label();
            this.timeButtonAM = new System.Windows.Forms.RadioButton();
            this.timeButtonPM = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.deleteScheduleButton = new System.Windows.Forms.Button();
            this.timeInputBox = new System.Windows.Forms.MaskedTextBox();
            this.timeGroup = new System.Windows.Forms.GroupBox();
            this.taskExistsLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            // ScheduleWarningLabel
            // 
            this.ScheduleWarningLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScheduleWarningLabel.AutoSize = true;
            this.ScheduleWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScheduleWarningLabel.ForeColor = System.Drawing.Color.Olive;
            this.ScheduleWarningLabel.Location = new System.Drawing.Point(31, 79);
            this.ScheduleWarningLabel.Name = "ScheduleWarningLabel";
            this.ScheduleWarningLabel.Size = new System.Drawing.Size(93, 12);
            this.ScheduleWarningLabel.TabIndex = 4;
            this.ScheduleWarningLabel.Text = "Computer must be on";
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
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "HH:MM";
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
            this.timeInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timeInputBox_KeyPress);
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
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 156);
            this.Controls.Add(this.taskExistsLabel);
            this.Controls.Add(this.timeGroup);
            this.Controls.Add(this.timeInputBox);
            this.Controls.Add(this.deleteScheduleButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ScheduleWarningLabel);
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
        private System.Windows.Forms.Label ScheduleWarningLabel;
        private System.Windows.Forms.RadioButton timeButtonAM;
        private System.Windows.Forms.RadioButton timeButtonPM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deleteScheduleButton;
        private System.Windows.Forms.MaskedTextBox timeInputBox;
        private System.Windows.Forms.GroupBox timeGroup;
        private System.Windows.Forms.Label taskExistsLabel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
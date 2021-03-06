﻿namespace GameDeal_App
{
    partial class ExtraSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraSettings));
            this.emailLabel = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.separationLabel = new System.Windows.Forms.Label();
            this.copyInputText = new System.Windows.Forms.TextBox();
            this.emailError = new System.Windows.Forms.Label();
            this.ccError = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.testButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(20, 15);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "Email:";
            this.toolTip.SetToolTip(this.emailLabel, "This email with get the message when a game is found on sale");
            // 
            // copyButton
            // 
            this.copyButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.copyButton.AutoSize = true;
            this.copyButton.Location = new System.Drawing.Point(15, 52);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(156, 17);
            this.copyButton.TabIndex = 10;
            this.copyButton.Text = "Send copies to other emails";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.CheckedChanged += new System.EventHandler(this.copyButton_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveButton.Location = new System.Drawing.Point(40, 87);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.toolTip.SetToolTip(this.saveButton, "Save settings");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // emailInput
            // 
            this.emailInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.emailInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.emailInput.Location = new System.Drawing.Point(61, 12);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(197, 20);
            this.emailInput.TabIndex = 8;
            this.toolTip.SetToolTip(this.emailInput, "Only Gmail accounts currently functioning. Sorry for any inconveniences!");
            this.emailInput.Enter += new System.EventHandler(this.emailInput_Enter);
            this.emailInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.emailInput_KeyDown);
            this.emailInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emailInput_KeyPress);
            this.emailInput.Leave += new System.EventHandler(this.emailInput_Leave);
            // 
            // separationLabel
            // 
            this.separationLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.separationLabel.AutoSize = true;
            this.separationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.separationLabel.Location = new System.Drawing.Point(59, 40);
            this.separationLabel.Name = "separationLabel";
            this.separationLabel.Size = new System.Drawing.Size(100, 12);
            this.separationLabel.TabIndex = 11;
            this.separationLabel.Text = "Seperate with commas";
            this.separationLabel.Visible = false;
            // 
            // copyInputText
            // 
            this.copyInputText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.copyInputText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.copyInputText.Enabled = false;
            this.copyInputText.Location = new System.Drawing.Point(61, 52);
            this.copyInputText.Name = "copyInputText";
            this.copyInputText.Size = new System.Drawing.Size(197, 20);
            this.copyInputText.TabIndex = 11;
            this.copyInputText.Visible = false;
            this.copyInputText.Enter += new System.EventHandler(this.copyInputText_Enter);
            this.copyInputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.copyInputText_KeyPress);
            this.copyInputText.Leave += new System.EventHandler(this.copyInputText_Leave);
            // 
            // emailError
            // 
            this.emailError.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.emailError.AutoSize = true;
            this.emailError.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailError.ForeColor = System.Drawing.Color.Red;
            this.emailError.Location = new System.Drawing.Point(200, 32);
            this.emailError.Name = "emailError";
            this.emailError.Size = new System.Drawing.Size(58, 12);
            this.emailError.TabIndex = 15;
            this.emailError.Text = "Invalid Email";
            this.emailError.Visible = false;
            // 
            // ccError
            // 
            this.ccError.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ccError.AutoSize = true;
            this.ccError.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccError.ForeColor = System.Drawing.Color.Red;
            this.ccError.Location = new System.Drawing.Point(189, 72);
            this.ccError.Name = "ccError";
            this.ccError.Size = new System.Drawing.Size(69, 12);
            this.ccError.TabIndex = 16;
            this.ccError.Text = "Invalid Email(s)";
            this.ccError.Visible = false;
            // 
            // testButton
            // 
            this.testButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.testButton.Location = new System.Drawing.Point(151, 87);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 14;
            this.testButton.Text = "Test Email";
            this.toolTip.SetToolTip(this.testButton, "Send an email to the above email provided using its own account");
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // ExtraSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(267, 122);
            this.Controls.Add(this.ccError);
            this.Controls.Add(this.emailError);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.separationLabel);
            this.Controls.Add(this.copyInputText);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.emailLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1080, 170);
            this.Name = "ExtraSettings";
            this.Text = "App settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.CheckBox copyButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.Label separationLabel;
        private System.Windows.Forms.TextBox copyInputText;
        private System.Windows.Forms.Label emailError;
        private System.Windows.Forms.Label ccError;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button testButton;
    }
}
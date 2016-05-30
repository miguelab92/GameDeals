namespace GameDeal_App
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
            this.emailLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.copyLabel = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.CheckBox();
            this.thoroughButton = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.passInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.copyInputText = new System.Windows.Forms.TextBox();
            this.thoroughWarning = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(32, 15);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(36, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "Gmail:";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(12, 39);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(56, 13);
            this.passLabel.TabIndex = 1;
            this.passLabel.Text = "Password:";
            // 
            // copyLabel
            // 
            this.copyLabel.AutoSize = true;
            this.copyLabel.Location = new System.Drawing.Point(12, 103);
            this.copyLabel.Name = "copyLabel";
            this.copyLabel.Size = new System.Drawing.Size(86, 13);
            this.copyLabel.TabIndex = 2;
            this.copyLabel.Text = "Send Copies To:";
            // 
            // copyButton
            // 
            this.copyButton.AutoSize = true;
            this.copyButton.Location = new System.Drawing.Point(15, 83);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(92, 17);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "Send Copies?";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.CheckedChanged += new System.EventHandler(this.copyButton_CheckedChanged);
            // 
            // thoroughButton
            // 
            this.thoroughButton.AutoSize = true;
            this.thoroughButton.Location = new System.Drawing.Point(15, 143);
            this.thoroughButton.Name = "thoroughButton";
            this.thoroughButton.Size = new System.Drawing.Size(115, 17);
            this.thoroughButton.TabIndex = 5;
            this.thoroughButton.Text = "Thorough Search?";
            this.thoroughButton.UseVisualStyleBackColor = true;
            this.thoroughButton.CheckedChanged += new System.EventHandler(this.thoroughButton_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(136, 166);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // emailInput
            // 
            this.emailInput.Location = new System.Drawing.Point(74, 12);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(159, 20);
            this.emailInput.TabIndex = 8;
            // 
            // passInput
            // 
            this.passInput.Location = new System.Drawing.Point(74, 39);
            this.passInput.Name = "passInput";
            this.passInput.PasswordChar = '*';
            this.passInput.Size = new System.Drawing.Size(159, 20);
            this.passInput.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Seperate with spaces";
            // 
            // copyInputText
            // 
            this.copyInputText.Enabled = false;
            this.copyInputText.Location = new System.Drawing.Point(104, 100);
            this.copyInputText.Name = "copyInputText";
            this.copyInputText.Size = new System.Drawing.Size(129, 20);
            this.copyInputText.TabIndex = 10;
            // 
            // thoroughWarning
            // 
            this.thoroughWarning.AutoSize = true;
            this.thoroughWarning.Location = new System.Drawing.Point(126, 144);
            this.thoroughWarning.Name = "thoroughWarning";
            this.thoroughWarning.Size = new System.Drawing.Size(107, 13);
            this.thoroughWarning.TabIndex = 12;
            this.thoroughWarning.Text = "(RECOMMEND OFF)";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(35, 166);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 13;
            this.testButton.Text = "Test Email";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // ExtraSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 201);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.thoroughWarning);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copyInputText);
            this.Controls.Add(this.passInput);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.thoroughButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.copyLabel);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.emailLabel);
            this.Name = "ExtraSettings";
            this.Text = "App settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label copyLabel;
        private System.Windows.Forms.CheckBox copyButton;
        private System.Windows.Forms.CheckBox thoroughButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.TextBox passInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox copyInputText;
        private System.Windows.Forms.Label thoroughWarning;
        private System.Windows.Forms.Button testButton;
    }
}
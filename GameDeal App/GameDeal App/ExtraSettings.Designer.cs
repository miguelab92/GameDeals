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
            this.copyButton = new System.Windows.Forms.CheckBox();
            this.thoroughButton = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.passInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.copyInputText = new System.Windows.Forms.TextBox();
            this.thoroughWarning = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.passError = new System.Windows.Forms.Label();
            this.emailError = new System.Windows.Forms.Label();
            this.ccError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(32, 15);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(36, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "Gmail:";
            // 
            // passLabel
            // 
            this.passLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(12, 48);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(56, 13);
            this.passLabel.TabIndex = 1;
            this.passLabel.Text = "Password:";
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.AutoSize = true;
            this.copyButton.Location = new System.Drawing.Point(15, 87);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(55, 17);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "    CC:";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.CheckedChanged += new System.EventHandler(this.copyButton_CheckedChanged);
            // 
            // thoroughButton
            // 
            this.thoroughButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.thoroughButton.AutoSize = true;
            this.thoroughButton.Location = new System.Drawing.Point(15, 136);
            this.thoroughButton.Name = "thoroughButton";
            this.thoroughButton.Size = new System.Drawing.Size(115, 17);
            this.thoroughButton.TabIndex = 5;
            this.thoroughButton.Text = "Thorough Search?";
            this.thoroughButton.UseVisualStyleBackColor = true;
            this.thoroughButton.CheckedChanged += new System.EventHandler(this.thoroughButton_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(148, 166);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // emailInput
            // 
            this.emailInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailInput.Location = new System.Drawing.Point(74, 12);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(184, 20);
            this.emailInput.TabIndex = 8;
            this.emailInput.Enter += new System.EventHandler(this.emailInput_Enter);
            this.emailInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emailInput_KeyPress);
            this.emailInput.Leave += new System.EventHandler(this.emailInput_Leave);
            // 
            // passInput
            // 
            this.passInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passInput.Location = new System.Drawing.Point(74, 48);
            this.passInput.Name = "passInput";
            this.passInput.PasswordChar = '*';
            this.passInput.Size = new System.Drawing.Size(184, 20);
            this.passInput.TabIndex = 9;
            this.passInput.Enter += new System.EventHandler(this.passInput_Enter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Seperate with commas";
            // 
            // copyInputText
            // 
            this.copyInputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyInputText.Enabled = false;
            this.copyInputText.Location = new System.Drawing.Point(74, 87);
            this.copyInputText.Name = "copyInputText";
            this.copyInputText.Size = new System.Drawing.Size(184, 20);
            this.copyInputText.TabIndex = 10;
            this.copyInputText.Enter += new System.EventHandler(this.copyInputText_Enter);
            this.copyInputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.copyInputText_KeyPress);
            this.copyInputText.Leave += new System.EventHandler(this.copyInputText_Leave);
            // 
            // thoroughWarning
            // 
            this.thoroughWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.thoroughWarning.AutoSize = true;
            this.thoroughWarning.Location = new System.Drawing.Point(126, 137);
            this.thoroughWarning.Name = "thoroughWarning";
            this.thoroughWarning.Size = new System.Drawing.Size(107, 13);
            this.thoroughWarning.TabIndex = 12;
            this.thoroughWarning.Text = "(RECOMMEND OFF)";
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testButton.Location = new System.Drawing.Point(46, 166);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 13;
            this.testButton.Text = "Test Email";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // passError
            // 
            this.passError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passError.AutoSize = true;
            this.passError.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passError.ForeColor = System.Drawing.Color.Red;
            this.passError.Location = new System.Drawing.Point(72, 72);
            this.passError.Name = "passError";
            this.passError.Size = new System.Drawing.Size(76, 12);
            this.passError.TabIndex = 14;
            this.passError.Text = "Empty Password";
            this.passError.Visible = false;
            // 
            // emailError
            // 
            this.emailError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailError.AutoSize = true;
            this.emailError.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailError.ForeColor = System.Drawing.Color.Red;
            this.emailError.Location = new System.Drawing.Point(72, 35);
            this.emailError.Name = "emailError";
            this.emailError.Size = new System.Drawing.Size(58, 12);
            this.emailError.TabIndex = 15;
            this.emailError.Text = "Invalid Email";
            this.emailError.Visible = false;
            // 
            // ccError
            // 
            this.ccError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ccError.AutoSize = true;
            this.ccError.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccError.ForeColor = System.Drawing.Color.Red;
            this.ccError.Location = new System.Drawing.Point(72, 110);
            this.ccError.Name = "ccError";
            this.ccError.Size = new System.Drawing.Size(69, 12);
            this.ccError.TabIndex = 16;
            this.ccError.Text = "Invalid Email(s)";
            this.ccError.Visible = false;
            // 
            // ExtraSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 201);
            this.Controls.Add(this.ccError);
            this.Controls.Add(this.emailError);
            this.Controls.Add(this.passError);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.thoroughWarning);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copyInputText);
            this.Controls.Add(this.passInput);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.thoroughButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.emailLabel);
            this.MaximumSize = new System.Drawing.Size(1080, 232);
            this.MinimumSize = new System.Drawing.Size(255, 232);
            this.Name = "ExtraSettings";
            this.Text = "App settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.CheckBox copyButton;
        private System.Windows.Forms.CheckBox thoroughButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.TextBox passInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox copyInputText;
        private System.Windows.Forms.Label thoroughWarning;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label passError;
        private System.Windows.Forms.Label emailError;
        private System.Windows.Forms.Label ccError;
    }
}
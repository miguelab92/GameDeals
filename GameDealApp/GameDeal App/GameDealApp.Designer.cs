namespace GameDeal_App
{
    partial class GameDealApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameDealApp));
            this.listBoxLabel = new System.Windows.Forms.Label();
            this.gamesList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.emailLabel = new System.Windows.Forms.Label();
            this.scheduleLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.moreButton = new System.Windows.Forms.Button();
            this.userFeedback = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxLabel
            // 
            this.listBoxLabel.AutoSize = true;
            this.listBoxLabel.Location = new System.Drawing.Point(9, 9);
            this.listBoxLabel.Name = "listBoxLabel";
            this.listBoxLabel.Size = new System.Drawing.Size(122, 13);
            this.listBoxLabel.TabIndex = 0;
            this.listBoxLabel.Text = "Search for these games:";
            // 
            // gamesList
            // 
            this.gamesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.gamesList.FormattingEnabled = true;
            this.gamesList.Location = new System.Drawing.Point(12, 25);
            this.gamesList.Name = "gamesList";
            this.gamesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.gamesList.Size = new System.Drawing.Size(322, 225);
            this.gamesList.TabIndex = 5;
            this.gamesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gamesList_KeyDown);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(222, 264);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(47, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remove.Location = new System.Drawing.Point(287, 264);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(47, 23);
            this.remove.TabIndex = 2;
            this.remove.Text = "Del";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // inputBox
            // 
            this.inputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputBox.Location = new System.Drawing.Point(12, 267);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(204, 20);
            this.inputBox.TabIndex = 0;
            this.inputBox.Enter += new System.EventHandler(this.inputBox_Enter);
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyDown);
            this.inputBox.Leave += new System.EventHandler(this.inputBox_Leave);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsButton.Location = new System.Drawing.Point(25, 301);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 23);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.Text = "Email Set-up";
            this.toolTip.SetToolTip(this.settingsButton, "Set up the email account to be notified when games go on sale");
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // scheduleButton
            // 
            this.scheduleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleButton.Location = new System.Drawing.Point(246, 301);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(75, 23);
            this.scheduleButton.TabIndex = 4;
            this.scheduleButton.Text = "Schedule";
            this.toolTip.SetToolTip(this.scheduleButton, "Set up schedule for program to run");
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.emailLabel.BackColor = System.Drawing.Color.Red;
            this.emailLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailLabel.Location = new System.Drawing.Point(12, 305);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(7, 16);
            this.emailLabel.TabIndex = 9;
            this.toolTip.SetToolTip(this.emailLabel, "Status of email set-up (Green: Done, Red:Pending)");
            // 
            // scheduleLabel
            // 
            this.scheduleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleLabel.BackColor = System.Drawing.Color.Red;
            this.scheduleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scheduleLabel.Location = new System.Drawing.Point(327, 305);
            this.scheduleLabel.Name = "scheduleLabel";
            this.scheduleLabel.Size = new System.Drawing.Size(7, 16);
            this.scheduleLabel.TabIndex = 10;
            this.toolTip.SetToolTip(this.scheduleLabel, "Status of scheduling set-up (Green: Done, Red:Pending)");
            // 
            // moreButton
            // 
            this.moreButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.moreButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.moreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreButton.Location = new System.Drawing.Point(169, 302);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(13, 23);
            this.moreButton.TabIndex = 11;
            this.moreButton.TabStop = false;
            this.moreButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.moreButton, "App info");
            this.moreButton.UseVisualStyleBackColor = false;
            this.moreButton.Visible = false;
            this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
            // 
            // userFeedback
            // 
            this.userFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userFeedback.ForeColor = System.Drawing.Color.Red;
            this.userFeedback.Location = new System.Drawing.Point(231, 10);
            this.userFeedback.Name = "userFeedback";
            this.userFeedback.Size = new System.Drawing.Size(103, 12);
            this.userFeedback.TabIndex = 12;
            this.userFeedback.Text = "[]";
            this.userFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userFeedback.Visible = false;
            this.userFeedback.Leave += new System.EventHandler(this.userFeedback_Leave);
            // 
            // GameDealApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(346, 336);
            this.Controls.Add(this.userFeedback);
            this.Controls.Add(this.moreButton);
            this.Controls.Add(this.scheduleLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.gamesList);
            this.Controls.Add(this.listBoxLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(264, 278);
            this.Name = "GameDealApp";
            this.Text = "GameDeal App";
            this.Load += new System.EventHandler(this.GameDealApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label listBoxLabel;
        private System.Windows.Forms.ListBox gamesList;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label scheduleLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button moreButton;
        private System.Windows.Forms.Label userFeedback;
    }
}


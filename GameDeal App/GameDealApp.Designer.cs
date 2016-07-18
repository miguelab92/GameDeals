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
            this.listBoxLabel = new System.Windows.Forms.Label();
            this.gamesList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.deleteErrorLabel = new System.Windows.Forms.Label();
            this.successLabel = new System.Windows.Forms.Label();
            this.noItemLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.scheduleLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.moreButton = new System.Windows.Forms.Button();
            this.gameInListError = new System.Windows.Forms.Label();
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
            this.gamesList.FormattingEnabled = true;
            this.gamesList.Location = new System.Drawing.Point(12, 25);
            this.gamesList.Name = "gamesList";
            this.gamesList.Size = new System.Drawing.Size(228, 147);
            this.gamesList.TabIndex = 5;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(137, 175);
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
            this.remove.Location = new System.Drawing.Point(193, 175);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(47, 23);
            this.remove.TabIndex = 2;
            this.remove.Text = "Del";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            this.remove.Leave += new System.EventHandler(this.remove_Leave);
            // 
            // inputBox
            // 
            this.inputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputBox.Location = new System.Drawing.Point(12, 178);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(119, 20);
            this.inputBox.TabIndex = 0;
            this.inputBox.Enter += new System.EventHandler(this.inputBox_Enter);
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyDown);
            this.inputBox.Leave += new System.EventHandler(this.inputBox_Leave);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsButton.Location = new System.Drawing.Point(25, 212);
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
            this.scheduleButton.Location = new System.Drawing.Point(152, 212);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(75, 23);
            this.scheduleButton.TabIndex = 4;
            this.scheduleButton.Text = "Schedule";
            this.toolTip.SetToolTip(this.scheduleButton, "Set up schedule for program to run");
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // deleteErrorLabel
            // 
            this.deleteErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteErrorLabel.AutoSize = true;
            this.deleteErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.deleteErrorLabel.Location = new System.Drawing.Point(166, 12);
            this.deleteErrorLabel.Name = "deleteErrorLabel";
            this.deleteErrorLabel.Size = new System.Drawing.Size(74, 12);
            this.deleteErrorLabel.TabIndex = 6;
            this.deleteErrorLabel.Text = "No item selected";
            this.deleteErrorLabel.Visible = false;
            this.deleteErrorLabel.Leave += new System.EventHandler(this.deleteErrorLabel_Leave);
            // 
            // successLabel
            // 
            this.successLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.successLabel.AutoSize = true;
            this.successLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.successLabel.ForeColor = System.Drawing.Color.Green;
            this.successLabel.Location = new System.Drawing.Point(147, 12);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(93, 12);
            this.successLabel.TabIndex = 7;
            this.successLabel.Text = "Successfully updated";
            this.successLabel.Visible = false;
            this.successLabel.VisibleChanged += new System.EventHandler(this.successLabel_VisibleChanged);
            // 
            // noItemLabel
            // 
            this.noItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.noItemLabel.AutoSize = true;
            this.noItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noItemLabel.ForeColor = System.Drawing.Color.Red;
            this.noItemLabel.Location = new System.Drawing.Point(149, 12);
            this.noItemLabel.Name = "noItemLabel";
            this.noItemLabel.Size = new System.Drawing.Size(91, 12);
            this.noItemLabel.TabIndex = 8;
            this.noItemLabel.Text = "No games to remove";
            this.noItemLabel.Visible = false;
            this.noItemLabel.Leave += new System.EventHandler(this.noItemLabel_Leave);
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.emailLabel.BackColor = System.Drawing.Color.Red;
            this.emailLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailLabel.Location = new System.Drawing.Point(12, 216);
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
            this.scheduleLabel.Location = new System.Drawing.Point(233, 216);
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
            this.moreButton.Location = new System.Drawing.Point(122, 213);
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
            // gameInListError
            // 
            this.gameInListError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameInListError.AutoSize = true;
            this.gameInListError.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInListError.ForeColor = System.Drawing.Color.Red;
            this.gameInListError.Location = new System.Drawing.Point(146, 12);
            this.gameInListError.Name = "gameInListError";
            this.gameInListError.Size = new System.Drawing.Size(94, 12);
            this.gameInListError.TabIndex = 12;
            this.gameInListError.Text = "Game is already in list";
            this.gameInListError.Visible = false;
            this.gameInListError.VisibleChanged += new System.EventHandler(this.gameInListError_VisibleChanged);
            // 
            // GameDealApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 247);
            this.Controls.Add(this.gameInListError);
            this.Controls.Add(this.moreButton);
            this.Controls.Add(this.scheduleLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.noItemLabel);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.deleteErrorLabel);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.gamesList);
            this.Controls.Add(this.listBoxLabel);
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
        private System.Windows.Forms.Label deleteErrorLabel;
        private System.Windows.Forms.Label successLabel;
        private System.Windows.Forms.Label noItemLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label scheduleLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button moreButton;
        private System.Windows.Forms.Label gameInListError;
    }
}


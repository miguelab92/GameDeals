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
            this.listBoxLabel = new System.Windows.Forms.Label();
            this.gamesList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.scheduleButton = new System.Windows.Forms.Button();
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
            this.gamesList.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(137, 177);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(36, 20);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remove.Location = new System.Drawing.Point(209, 177);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(31, 20);
            this.remove.TabIndex = 3;
            this.remove.Text = "Del";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // inputBox
            // 
            this.inputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputBox.Location = new System.Drawing.Point(12, 178);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(119, 20);
            this.inputBox.TabIndex = 0;
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyDown);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.settingsButton.Location = new System.Drawing.Point(39, 212);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 23);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.Text = "Email Set-up";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // scheduleButton
            // 
            this.scheduleButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.scheduleButton.Location = new System.Drawing.Point(149, 212);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(75, 23);
            this.scheduleButton.TabIndex = 7;
            this.scheduleButton.Text = "Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // GameDealApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 247);
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
    }
}


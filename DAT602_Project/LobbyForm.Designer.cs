namespace DAT602_Project
{
    partial class lobbyForm
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
            this.playersListBox = new System.Windows.Forms.ListBox();
            this.gamesListBox = new System.Windows.Forms.ListBox();
            this.newGameButton = new System.Windows.Forms.Button();
            this.playersLabel = new System.Windows.Forms.Label();
            this.gamesLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.joinGameButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.deleteAccountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playersListBox
            // 
            this.playersListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playersListBox.Enabled = false;
            this.playersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersListBox.FormattingEnabled = true;
            this.playersListBox.ItemHeight = 20;
            this.playersListBox.Items.AddRange(new object[] {
            "John",
            "Jane",
            "Jim"});
            this.playersListBox.Location = new System.Drawing.Point(12, 64);
            this.playersListBox.Name = "playersListBox";
            this.playersListBox.Size = new System.Drawing.Size(158, 144);
            this.playersListBox.TabIndex = 0;
            // 
            // gamesListBox
            // 
            this.gamesListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamesListBox.FormattingEnabled = true;
            this.gamesListBox.ItemHeight = 20;
            this.gamesListBox.Items.AddRange(new object[] {
            "John\'s Game (1)"});
            this.gamesListBox.Location = new System.Drawing.Point(305, 64);
            this.gamesListBox.Name = "gamesListBox";
            this.gamesListBox.Size = new System.Drawing.Size(158, 144);
            this.gamesListBox.TabIndex = 1;
            // 
            // newGameButton
            // 
            this.newGameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newGameButton.Location = new System.Drawing.Point(191, 64);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(91, 46);
            this.newGameButton.TabIndex = 2;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // playersLabel
            // 
            this.playersLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(12, 45);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(53, 16);
            this.playersLabel.TabIndex = 3;
            this.playersLabel.Text = "Players";
            // 
            // gamesLabel
            // 
            this.gamesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamesLabel.AutoSize = true;
            this.gamesLabel.Location = new System.Drawing.Point(302, 45);
            this.gamesLabel.Name = "gamesLabel";
            this.gamesLabel.Size = new System.Drawing.Size(91, 16);
            this.gamesLabel.TabIndex = 4;
            this.gamesLabel.Text = "Active Games";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Logged in as: John";
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoutButton.Location = new System.Drawing.Point(15, 260);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(81, 27);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // joinGameButton
            // 
            this.joinGameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.joinGameButton.Location = new System.Drawing.Point(191, 131);
            this.joinGameButton.Name = "joinGameButton";
            this.joinGameButton.Size = new System.Drawing.Size(91, 44);
            this.joinGameButton.TabIndex = 7;
            this.joinGameButton.Text = "Join Game";
            this.joinGameButton.UseVisualStyleBackColor = true;
            // 
            // adminButton
            // 
            this.adminButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.adminButton.Location = new System.Drawing.Point(348, 260);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(115, 27);
            this.adminButton.TabIndex = 8;
            this.adminButton.Text = "Administrator";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // deleteAccountButton
            // 
            this.deleteAccountButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteAccountButton.Location = new System.Drawing.Point(220, 260);
            this.deleteAccountButton.Name = "deleteAccountButton";
            this.deleteAccountButton.Size = new System.Drawing.Size(122, 27);
            this.deleteAccountButton.TabIndex = 9;
            this.deleteAccountButton.Text = "Delete Account";
            this.deleteAccountButton.UseVisualStyleBackColor = true;
            // 
            // lobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 299);
            this.Controls.Add(this.deleteAccountButton);
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.joinGameButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gamesLabel);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.gamesListBox);
            this.Controls.Add(this.playersListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "lobbyForm";
            this.Text = "Lobby";
            this.Load += new System.EventHandler(this.lobbyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox playersListBox;
        private System.Windows.Forms.ListBox gamesListBox;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Label gamesLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button joinGameButton;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Button deleteAccountButton;
    }
}
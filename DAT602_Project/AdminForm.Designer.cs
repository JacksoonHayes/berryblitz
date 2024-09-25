namespace DAT602_Project
{
    partial class adminForm
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
            this.playersLabel = new System.Windows.Forms.Label();
            this.gamesLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playersListBox
            // 
            this.playersListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playersListBox.FormattingEnabled = true;
            this.playersListBox.ItemHeight = 16;
            this.playersListBox.Location = new System.Drawing.Point(12, 40);
            this.playersListBox.Name = "playersListBox";
            this.playersListBox.Size = new System.Drawing.Size(172, 212);
            this.playersListBox.TabIndex = 0;
            // 
            // gamesListBox
            // 
            this.gamesListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamesListBox.FormattingEnabled = true;
            this.gamesListBox.ItemHeight = 16;
            this.gamesListBox.Items.AddRange(new object[] {
            "John\'s Game (1)"});
            this.gamesListBox.Location = new System.Drawing.Point(190, 40);
            this.gamesListBox.Name = "gamesListBox";
            this.gamesListBox.Size = new System.Drawing.Size(163, 212);
            this.gamesListBox.TabIndex = 1;
            // 
            // playersLabel
            // 
            this.playersLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(9, 21);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(53, 16);
            this.playersLabel.TabIndex = 2;
            this.playersLabel.Text = "Players";
            // 
            // gamesLabel
            // 
            this.gamesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamesLabel.AutoSize = true;
            this.gamesLabel.Location = new System.Drawing.Point(187, 21);
            this.gamesLabel.Name = "gamesLabel";
            this.gamesLabel.Size = new System.Drawing.Size(96, 16);
            this.gamesLabel.TabIndex = 3;
            this.gamesLabel.Text = "Current Games";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteButton.Location = new System.Drawing.Point(229, 271);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(89, 29);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click_1);
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addButton.Location = new System.Drawing.Point(12, 271);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(89, 29);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add Player";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editButton.Location = new System.Drawing.Point(121, 271);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(89, 29);
            this.editButton.TabIndex = 7;
            this.editButton.Text = "Edit Player";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // adminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 321);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.gamesLabel);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.gamesListBox);
            this.Controls.Add(this.playersListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "adminForm";
            this.Text = "Admin Console";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox playersListBox;
        private System.Windows.Forms.ListBox gamesListBox;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Label gamesLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
    }
}
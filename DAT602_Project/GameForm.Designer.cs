namespace DAT602_Project
{
    partial class gameForm
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
            this.gameGrid = new System.Windows.Forms.DataGridView();
            this.gameLabel = new System.Windows.Forms.Label();
            this.chatListBox = new System.Windows.Forms.ListBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.leaveButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.placeItemButton = new System.Windows.Forms.Button();
            this.movePlayerButton = new System.Windows.Forms.Button();
            this.acquireItemButton = new System.Windows.Forms.Button();
            this.updateScoreButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gameGrid
            // 
            this.gameGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameGrid.Location = new System.Drawing.Point(12, 57);
            this.gameGrid.Name = "gameGrid";
            this.gameGrid.RowHeadersWidth = 51;
            this.gameGrid.Size = new System.Drawing.Size(514, 308);
            this.gameGrid.TabIndex = 0;
            // 
            // gameLabel
            // 
            this.gameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameLabel.AutoSize = true;
            this.gameLabel.Location = new System.Drawing.Point(12, 9);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(86, 16);
            this.gameLabel.TabIndex = 1;
            this.gameLabel.Text = "John\'s Game";
            // 
            // chatListBox
            // 
            this.chatListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chatListBox.FormattingEnabled = true;
            this.chatListBox.ItemHeight = 16;
            this.chatListBox.Items.AddRange(new object[] {
            "John: Hello!",
            "Jim: Hi",
            "John: Are you ready to ",
            "play?"});
            this.chatListBox.Location = new System.Drawing.Point(546, 57);
            this.chatListBox.Name = "chatListBox";
            this.chatListBox.Size = new System.Drawing.Size(161, 196);
            this.chatListBox.TabIndex = 2;
            this.chatListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.messageTextBox.Location = new System.Drawing.Point(546, 259);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(161, 22);
            this.messageTextBox.TabIndex = 3;
            this.messageTextBox.Text = "Enter Message\r\n\r\n";
            // 
            // sendButton
            // 
            this.sendButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendButton.Location = new System.Drawing.Point(640, 287);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(67, 27);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // leaveButton
            // 
            this.leaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leaveButton.Location = new System.Drawing.Point(607, 411);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(100, 27);
            this.leaveButton.TabIndex = 5;
            this.leaveButton.Text = "Leave Game";
            this.leaveButton.UseVisualStyleBackColor = true;
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(12, 38);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(78, 16);
            this.timeLabel.TabIndex = 6;
            this.timeLabel.Text = "Time: 0:00";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "John\'s Score: 0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Jim\'s Score: 100";
            // 
            // placeItemButton
            // 
            this.placeItemButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.placeItemButton.Location = new System.Drawing.Point(135, 163);
            this.placeItemButton.Name = "placeItemButton";
            this.placeItemButton.Size = new System.Drawing.Size(100, 27);
            this.placeItemButton.TabIndex = 9;
            this.placeItemButton.Text = "Place Item";
            this.placeItemButton.UseVisualStyleBackColor = true;
            this.placeItemButton.Click += new System.EventHandler(this.placeItemButton_Click);
            // 
            // movePlayerButton
            // 
            this.movePlayerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.movePlayerButton.Location = new System.Drawing.Point(279, 163);
            this.movePlayerButton.Name = "movePlayerButton";
            this.movePlayerButton.Size = new System.Drawing.Size(100, 27);
            this.movePlayerButton.TabIndex = 10;
            this.movePlayerButton.Text = "Move Player";
            this.movePlayerButton.UseVisualStyleBackColor = true;
            this.movePlayerButton.Click += new System.EventHandler(this.movePlayerButton_Click);
            // 
            // acquireItemButton
            // 
            this.acquireItemButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.acquireItemButton.Location = new System.Drawing.Point(135, 220);
            this.acquireItemButton.Name = "acquireItemButton";
            this.acquireItemButton.Size = new System.Drawing.Size(100, 27);
            this.acquireItemButton.TabIndex = 11;
            this.acquireItemButton.Text = "Acquire Item";
            this.acquireItemButton.UseVisualStyleBackColor = true;
            this.acquireItemButton.Click += new System.EventHandler(this.acquireItemButton_Click);
            // 
            // updateScoreButton
            // 
            this.updateScoreButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.updateScoreButton.Location = new System.Drawing.Point(279, 222);
            this.updateScoreButton.Name = "updateScoreButton";
            this.updateScoreButton.Size = new System.Drawing.Size(100, 27);
            this.updateScoreButton.TabIndex = 12;
            this.updateScoreButton.Text = "Update Score";
            this.updateScoreButton.UseVisualStyleBackColor = true;
            this.updateScoreButton.Click += new System.EventHandler(this.updateScoreButton_Click);
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Controls.Add(this.updateScoreButton);
            this.Controls.Add(this.acquireItemButton);
            this.Controls.Add(this.movePlayerButton);
            this.Controls.Add(this.placeItemButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.leaveButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.chatListBox);
            this.Controls.Add(this.gameLabel);
            this.Controls.Add(this.gameGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "gameForm";
            this.Text = "GameForm";
            ((System.ComponentModel.ISupportInitialize)(this.gameGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gameGrid;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.ListBox chatListBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button leaveButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button placeItemButton;
        private System.Windows.Forms.Button movePlayerButton;
        private System.Windows.Forms.Button acquireItemButton;
        private System.Windows.Forms.Button updateScoreButton;
    }
}
namespace DAT602_Project
{
    partial class landingForm
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
            this.loginFormButton = new System.Windows.Forms.Button();
            this.registerFormButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginFormButton
            // 
            this.loginFormButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginFormButton.Location = new System.Drawing.Point(143, 127);
            this.loginFormButton.Name = "loginFormButton";
            this.loginFormButton.Size = new System.Drawing.Size(132, 34);
            this.loginFormButton.TabIndex = 0;
            this.loginFormButton.Text = "Login";
            this.loginFormButton.UseVisualStyleBackColor = true;
            this.loginFormButton.Click += new System.EventHandler(this.loginFormButton_Click);
            // 
            // registerFormButton
            // 
            this.registerFormButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.registerFormButton.Location = new System.Drawing.Point(143, 194);
            this.registerFormButton.Name = "registerFormButton";
            this.registerFormButton.Size = new System.Drawing.Size(132, 34);
            this.registerFormButton.TabIndex = 1;
            this.registerFormButton.Text = "Register";
            this.registerFormButton.UseVisualStyleBackColor = true;
            this.registerFormButton.Click += new System.EventHandler(this.registerFormButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("MV Boli", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(94, 35);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(226, 52);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Berry Blitz";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.closeButton.Location = new System.Drawing.Point(325, 274);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 13;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // landingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 320);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.registerFormButton);
            this.Controls.Add(this.loginFormButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "landingForm";
            this.Text = "Login / Register";
            this.Load += new System.EventHandler(this.LandingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginFormButton;
        private System.Windows.Forms.Button registerFormButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button closeButton;
    }
}
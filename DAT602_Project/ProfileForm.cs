using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602_Project
{
    public partial class ProfileForm : Form
    {
        private int playerId;

        public ProfileForm(int playerId, string username, string password, string email, bool lockedOut, bool banned)
        {
            InitializeComponent();

            this.playerId = playerId; // Store the player ID for updating later
            usernameTextBox.Text = username;
            passwordTextBox.Text = password;
            emailTextBox.Text = email;
            lockedCheckBox.Checked = lockedOut;
            bannedCheckBox.Checked = banned;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string email = emailTextBox.Text;
            bool locked_out = lockedCheckBox.Checked;
            bool is_banned = bannedCheckBox.Checked;

            try
            {
                AdminDAO adminDAO = new AdminDAO();
                string result = adminDAO.updatePlayerProfile(playerId, username, password, email, locked_out, is_banned);
                if (result == "Transaction Commited. Player profile updated successfully")
                {
                    MessageBox.Show("Profile updated successfully", "Success");
                }
                else if (result == "Transaction rolled back. Profile Updating Error")
                {
                    MessageBox.Show("Failed to update user profile: " + result, "Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating player profile: " + ex.Message, "Update Failed");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}

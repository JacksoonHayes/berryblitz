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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if ((usernameTextBox.Text == "") || (passwordTextBox.Text == ""))
            {
                MessageBox.Show("Please fill in all fields", "Error");
                return;
            }
            else
            {
                try
                {
                    var dbAccess = new LoginDAO();
                    string result = dbAccess.loginUser(usernameTextBox.Text, passwordTextBox.Text);
                    if (result == "Transaction committed")
                    {
                        Player.CurrentPlayer = new Player();
                        new lobbyForm().Show();
                        MessageBox.Show("Logged in successfully.", "Success");
                    }
                    else if (result == "Transaction rolled back")
                    {
                        MessageBox.Show("Failed to log in: " + result, "Error");
                    }
                    else if (result == "Locked Out") 
                    {
                        MessageBox.Show(result, "You have been locked out");
                    }
                    else
                    {
                        MessageBox.Show(result, "Login Failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while trying to log in: " + ex.Message, "Error");
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

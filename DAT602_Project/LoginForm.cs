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
                    var dbAccess = new DataAccess();
                    string result = dbAccess.Login(usernameTextBox.Text, passwordTextBox.Text);

                    if (result == "Login successful")
                    {
                        new lobbyForm().Show();
                        MessageBox.Show(result, "Success");
                        Player.CurrentPlayer = new Player
                        {
                            username = usernameTextBox.Text,
                            score = 1000
                        };
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

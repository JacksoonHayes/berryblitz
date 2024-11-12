using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602_Project
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if ((usernameTextBox.Text == "") || (passwordTextBox.Text == "") || (emailTextBox.Text == ""))
            {
                MessageBox.Show("Please fill in all fields", "Error");
                return;
            }
            else if (passwordTextBox.Text != confirmTextBox.Text)
            {
                MessageBox.Show("Passwords do not match", "Error");
                return;
            }
            else if (!emailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Invalid email address format", "Error");
                return;
            }
            else
            {
                try 
                {
                    var dbAccess = new LoginDAO();
                    string result = dbAccess.registerUser(usernameTextBox.Text, passwordTextBox.Text, emailTextBox.Text);

                    if (result == "Transaction Committed. Added new user")
                    {
                        MessageBox.Show("Account registered successfully.", "Success");
                    }
                    else if (result == "Transaction rolled back. Registration Error")
                    {
                        MessageBox.Show("Failed to register account: " + result, "Error");
                    }
                    else if(result == "Account with that name already exists!")
                    {
                        MessageBox.Show(result, "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while trying to register: " + ex.Message, "Error");
                }   
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

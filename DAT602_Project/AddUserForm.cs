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
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if ((usernameTextBox.Text == "") || (passwordTextBox.Text == "") || (emailTextBox.Text == ""))
            {
                MessageBox.Show("Please fill in all fields", "Error");
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
                    var dbAccess = new AdminDAO();
                    string result = dbAccess.addUser(usernameTextBox.Text, passwordTextBox.Text, emailTextBox.Text);

                    if (result == "Transaction Committed. Added New User")
                    {
                        MessageBox.Show("User added successfully.", "Success");
                    }
                    else if (result == "Transaction rolled back. Add User Error")
                    {
                        MessageBox.Show("Failed to add user: " + result, "Error");
                    }
                    else if (result == "Account with that name already exists!")
                    {
                        MessageBox.Show(result, "Error");
                    }
                    else
                    {
                        MessageBox.Show("Unexpected response: " + result, "Info");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while trying to add a user: " + ex.Message, "Error");
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

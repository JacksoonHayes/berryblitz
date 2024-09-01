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
    public partial class LandingForm : Form
    {
        public LandingForm()
        {
            InitializeComponent();
        }

        private void loginFormButton_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
        }

        private void registerFormButton_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
        }
    }
}

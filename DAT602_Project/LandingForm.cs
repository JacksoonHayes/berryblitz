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
    public partial class landingForm : Form
    {
        public landingForm()
        {
            InitializeComponent();
        }

        private void loginFormButton_Click(object sender, EventArgs e)
        {
            new loginForm().Show();
        }

        private void registerFormButton_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
        }

        private void LandingForm_Load(object sender, EventArgs e)
        {

        }
    }
}

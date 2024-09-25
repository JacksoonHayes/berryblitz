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
    public partial class lobbyForm : Form
    {
        public lobbyForm()
        {
            InitializeComponent();
        }

        private void gamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dbAccess = new GameplayDAO();
                MessageBox.Show(dbAccess.CreateGame());
                new gameForm().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating a game: " + ex.Message, "Error");
            }
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            new adminForm().Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

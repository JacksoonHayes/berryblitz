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
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                var dbAccess = new AdminDAO();
                List<Player> players = dbAccess.getAllPlayers();
                List<Game> games = dbAccess.getAllGames();

                playersListBox.Items.Clear();
                gamesListBox.Items.Clear();

                foreach (var player in players)
                {
                    // Add each player's details to the list
                    playersListBox.Items.Add($"{player.username}  -  Score: {player.score}");
                }
                foreach (var game in games)
                {
                    // Add each game's details to the list
                    gamesListBox.Items.Add($"ID:{game.game_id}  -  {game.status}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving data: " + ex.Message, "Error");

            }
        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}

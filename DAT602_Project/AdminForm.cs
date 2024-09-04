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
                var dbAccess = new DataAccess();
                List<Player> players = dbAccess.GetAllPlayers();
                List<Game> games = dbAccess.GetAllGames();

                playersListBox.Items.Clear();
                gamesListBox.Items.Clear();

                foreach (var player in players)
                {
                    // Add each player's details to the list
                    playersListBox.Items.Add($"{player.username} - Score: {player.score}");
                }
                foreach (var game in games)
                {
                    // Add each game's details to the list
                    gamesListBox.Items.Add($"Game ID:{game.game_id}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving data: " + ex.Message, "Error");

            }
        }

       /* private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dbAccess = new DataAccess();
                string result = string.Empty;

                // Check if a player is selected
                if (playersListBox.SelectedItem != null)
                {
                    string selectedItem = playersListBox.SelectedItem.ToString();
                    int playerId = int.Parse(selectedItem.Split(':')[0].Trim());
                    result = dbAccess.DeletePlayer(playerId);

                    // Remove the item from the ListBox
                    playersListBox.Items.Remove(playersListBox.SelectedItem);
                }
                // Check if a game is selected
                else if (gamesListBox.SelectedItem != null)
                {
                    string selectedItem = gamesListBox.SelectedItem.ToString();
                    int gameId = int.Parse(selectedItem.Split(':')[0].Trim());
                    result = dbAccess.DeleteGame(gameId);

                    // Remove the item from the ListBox
                    gamesListBox.Items.Remove(gamesListBox.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Please select a record to delete", "Error");
                    return;
                }

                MessageBox.Show(result, "Delete Record");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to delete the record: " + ex.Message, "Error");
            }
        }*/
    }
}

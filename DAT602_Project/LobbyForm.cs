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

        private void lobbyForm_Load(object sender, EventArgs e)
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
                    playersListBox.Items.Add(player); // Add Player objects into the listbox
                }
                playersListBox.DisplayMember = "username"; // Display only the username in the listbox

                foreach (var game in games)
                {
                    // Add each game's details to the list
                    gamesListBox.Items.Add(game);
                }
                gamesListBox.DisplayMember = "game_id"; // Display only the game name in the listbox
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving data: " + ex.Message, "Error");

            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dbAccess = new GameplayDAO();
                string result = dbAccess.makeBoard();
                lobbyForm_Load(sender, e);

                if (result == "Transaction committed")
                {
                    MessageBox.Show("New game create successfully.", "Success");
                    new gameForm().Show();
                }
                else if (result == "Transaction rolled back")
                {
                    MessageBox.Show("Failed to create a new game: " + result, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to create a new game: " + ex.Message, "Error");
            }
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            try {
                new adminForm().Show();
                lobbyForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to access the admin panel: " + ex.Message, "Error");
            }

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

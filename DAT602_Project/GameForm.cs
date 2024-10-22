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
    public partial class gameForm : Form
    {
        public gameForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void placeItemButton_Click(object sender, EventArgs e)
        {
            int gameId = 5;
            int itemId = 2;
            int row = 1;
            int col = 1;

            try
            {
                var dbAccess = new GameplayDAO();
                string result = dbAccess.placeItemOnTile(gameId, itemId, row, col);
                if (result == $"Item placed successfully on tile: {row}, {col}")
                {
                    MessageBox.Show(result, "Success");
                }
                else
                {
                    MessageBox.Show(result, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while placing the item: " + ex.Message, "Error");
            }

        }

        private void movePlayerButton_Click(object sender, EventArgs e)
        {
            int playerId = 1;
            int gameId = 5;
            int newRow = 0;
            int newCol = 1;

            try {
                
                var dbAccess = new GameplayDAO();
                string result = dbAccess.movePlayer(playerId, gameId, newRow, newCol);
                if (result == $"Player moved successfully to tile: {newRow}, {newCol}")
                {
                    MessageBox.Show(result, "Success");
                }
                else
                {
                    MessageBox.Show(result, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while moving the player: " + ex.Message, "Error");
            }
        }

        private void acquireItemButton_Click(object sender, EventArgs e)
        {
            int playerID = 1;
            int tileID = 16;

            try
            {
                var dbAccess = new GameplayDAO();
                string result = dbAccess.acquireItem(playerID, tileID);
                if (result == "Item added to inventory")
                {
                    MessageBox.Show(result, "Success");
                }
                else
                {
                    MessageBox.Show(result, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while acquiring the item: " + ex.Message, "Error");
            }
        }

        private void updateScoreButton_Click(object sender, EventArgs e)
        {
            int playerID = 1;
            int tileID = 30;

            try
            {
                var dbAccess = new GameplayDAO();
                string result = dbAccess.updatePlayerScore(playerID, tileID);
                MessageBox.Show(result, "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while acquiring the item: " + ex.Message, "Error");
            }
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void moveThornsButton_Click(object sender, EventArgs e)
        {
            int gameId = 5;

            try
            {
                var dbAccess = new GameplayDAO();
                string result = dbAccess.moveThorns(gameId);
                if (result == "Thorns (NPC) moved successfully")
                {
                    MessageBox.Show(result, "Success");
                }
                else
                {
                    MessageBox.Show(result, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while moving the thorns: " + ex.Message, "Error");
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Project
{
    internal class GameplayDAO : DataAccess
    {
        // Preset values for rows and columns
        private const int MaxRow = 10;
        private const int MaxCol = 10;

        public string makeBoard()
        {
            List<MySqlParameter> p = new List<MySqlParameter>();

            var aP_maxRow = new MySqlParameter("@p_max_row", MySqlDbType.Int32);
            var aP_maxCol = new MySqlParameter("@p_max_col", MySqlDbType.Int32);

            aP_maxRow.Value = MaxRow;
            aP_maxCol.Value = MaxCol;

            p.Add(aP_maxRow);
            p.Add(aP_maxCol);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call makeBoard(@p_max_row, @p_max_col)", p.ToArray());

            return aDataSet.Tables[0].Rows[0]["Message"].ToString();
        }

        public string placeItemOnTile(int gameId, int itemId, int row, int col)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();

            var aP_gameId = new MySqlParameter("@p_game_id", MySqlDbType.Int32);
            var aP_row = new MySqlParameter("@p_row", MySqlDbType.Int32);
            var aP_col = new MySqlParameter("@p_col", MySqlDbType.Int32);
            var aP_itemId = new MySqlParameter("@p_item_id", MySqlDbType.Int32);

            aP_gameId.Value = gameId;
            aP_row.Value = row;
            aP_col.Value = col;
            aP_itemId.Value = itemId;

            p.Add(aP_gameId);
            p.Add(aP_row);
            p.Add(aP_col);
            p.Add(aP_itemId);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call placeItemOnTile(@p_game_id, @p_row, @p_col, @p_item_id)", p.ToArray());

            return aDataSet.Tables[0].Rows[0]["Message"].ToString();
        }

        public string movePlayer(int playerId, int gameId, int newRow, int newCol)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();

            var aP_playerId = new MySqlParameter("@p_player_id", MySqlDbType.Int32);
            var aP_gameId = new MySqlParameter("@p_game_id", MySqlDbType.Int32);
            var aP_newRow = new MySqlParameter("@p_new_row", MySqlDbType.Int32);
            var aP_newCol = new MySqlParameter("@p_new_col", MySqlDbType.Int32);

            aP_playerId.Value = playerId;
            aP_gameId.Value = gameId;
            aP_newRow.Value = newRow;
            aP_newCol.Value = newCol;

            p.Add(aP_playerId);
            p.Add(aP_gameId);
            p.Add(aP_newRow);
            p.Add(aP_newCol);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call movePlayer(@p_player_id, @p_game_id, @p_new_row, @p_new_col)", p.ToArray());

            return aDataSet.Tables[0].Rows[0]["message"].ToString();
        }

        public string updatePlayerScore(int playerId, int tileId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();

            var aP_playerId = new MySqlParameter("@p_player_id", MySqlDbType.Int32);
            var aP_tileId = new MySqlParameter("@p_tile_id", MySqlDbType.Int32);

            aP_playerId.Value = playerId;
            aP_tileId.Value = tileId;

            p.Add(aP_playerId);
            p.Add(aP_tileId);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call updatePlayerScore(@p_player_id, @p_tile_id)", p.ToArray());

            return aDataSet.Tables[0].Rows[0]["message"].ToString();
        }

        public string acquireItem(int playerId, int tileId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();

            var aP_playerId = new MySqlParameter("@p_player_id", MySqlDbType.Int32);
            var aP_tileId = new MySqlParameter("@p_tile_id", MySqlDbType.Int32);

            aP_playerId.Value = playerId;
            aP_tileId.Value = tileId;

            p.Add(aP_playerId);
            p.Add(aP_tileId);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call acquireItem(@p_player_id, @p_tile_id)", p.ToArray());

            return aDataSet.Tables[0].Rows[0]["message"].ToString();
        }

        public string moveThorns(int gmaeId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();

            var aP_gameId = new MySqlParameter("@p_game_id", MySqlDbType.Int32);

            aP_gameId.Value = gmaeId;

            p.Add(aP_gameId);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call moveThorns(@p_game_id)", p.ToArray());

            return aDataSet.Tables[0].Rows[0]["message"].ToString();
        }
    }
}

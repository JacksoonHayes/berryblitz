using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Project
{
    internal class AdminDAO : DataAccess
    {
        public List<Player> GetAllPlayers()
        {
            List<Player> lcPlayers = new List<Player>();

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetAllPlayers()");
            lcPlayers = (from aResult in System.Data.DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                         select
                            new Player
                            {
                                username = aResult["username"].ToString(),
                                score = Convert.ToInt32(aResult["score"]),
                            }).ToList();
            return lcPlayers;
        }
        public List<Game> GetAllGames()
        {
            List<Game> lcGames = new List<Game>();

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetAllGames()");
            lcGames = (from aResult in System.Data.DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                       select
                            new Game
                            {
                                game_id = Convert.ToInt32(aResult["game_id"]),
                                status = aResult["status"].ToString(),
                            }).ToList();
            return lcGames;
        }

        public string DeletePlayer(int pPlayerId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP_playerId = new MySqlParameter("@PlayerId", MySqlDbType.Int32);
            aP_playerId.Value = pPlayerId;

            p.Add(aP_playerId);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call DeletePlayer(@PlayerId)", p.ToArray());

            return (aDataSet.Tables[0].Rows[0])["Message"].ToString();
        }

        /*public string DeleteGame(int gameId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP_gameId = new MySqlParameter("@GameId", MySqlDbType.Int32);
            aP_gameId.Value = gameId;
            p.Add(aP_gameId);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call DeleteGame(@GameId)", p.ToArray());

            return (aDataSet.Tables[0].Rows[0])["Message"].ToString();
        }*/
    }
}

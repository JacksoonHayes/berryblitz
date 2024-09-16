using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAT602_Project
{
    internal class DataAccess
    {
        private static string connectionString
        {
            get { return "Server=localhost;Port=3306;Database=dat602;Uid=sapo;password=53211;"; }
        }

        private static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection mySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(connectionString);
                }

                return _mySqlConnection;

            }
        }
        public string Login(string pUserName, string pPassword)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP_username = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
            var aP_password = new MySqlParameter("@Password", MySqlDbType.VarChar, 50);

            aP_username.Value = pUserName;
            aP_password.Value = pPassword;

            p.Add(aP_username);
            p.Add(aP_password);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call Login(@UserName, @Password)", p.ToArray());
            return (aDataSet.Tables[0].Rows[0])["Message"].ToString();
        }

        public string RegisterUser(string pUserName, string pPassword, string pEmail)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP_username = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
            var aP_password = new MySqlParameter("@Password", MySqlDbType.VarChar, 50);
            var aP_email = new MySqlParameter("@Email", MySqlDbType.VarChar, 100);

            aP_username.Value = pUserName;
            aP_password.Value = pPassword;
            aP_email.Value = pEmail;
            
            p.Add(aP_username);
            p.Add(aP_password);
            p.Add(aP_email);


            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call RegisterUser(@UserName, @Password, @Email)", p.ToArray());
            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

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
        public List<Game> GetAllGames ()
        {
            List<Game> lcGames = new List<Game>();

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetAllGames()");
            lcGames = (from aResult in System.Data.DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                       select
                            new Game
                            {
                                game_id = Convert.ToInt32(aResult["game_id"]),
                            }).ToList();
            return lcGames;
        }

        public string CreateGame()
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP_startTime = new MySqlParameter("@StartTime", MySqlDbType.Time);

            aP_startTime.Value = DateTime.Now.TimeOfDay;

            p.Add(aP_startTime);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call CreateGame(@StartTime)", p.ToArray());

            return (aDataSet.Tables[0].Rows[0])["Message"].ToString();
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

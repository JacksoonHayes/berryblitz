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
        public List<Player> getAllPlayers()
        {
            try
            {
                List<Player> lcPlayers = new List<Player>();

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call getAllPlayers()");
                lcPlayers = (from aResult in System.Data.DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                             select
                                new Player
                                {
                                    player_id = Convert.ToInt32(aResult["player_id"]),
                                    username = aResult["username"].ToString(),
                                    score = Convert.ToInt32(aResult["score"]),
                                    email = aResult["email"].ToString(),
                                    password = aResult["password"].ToString(),
                                    locked_out = Convert.ToBoolean(aResult["locked_out"]),
                                    is_banned = Convert.ToBoolean(aResult["is_banned"]),
                                }).ToList();
                return lcPlayers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Game> getAllGames()
        {
            try
            {
                List<Game> lcGames = new List<Game>();

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call getAllGames()");
                lcGames = (from aResult in System.Data.DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                           select
                                new Game
                                {
                                    game_id = Convert.ToInt32(aResult["game_id"]),
                                    status = aResult["status"].ToString(),
                                }).ToList();
                return lcGames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string addUser(string pUsername, string pPassword, string pEmail)
        {
            try
            {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var aP_username = new MySqlParameter("@Username", MySqlDbType.VarChar);
                var aP_password = new MySqlParameter("@Password", MySqlDbType.VarChar);
                var aP_email = new MySqlParameter("@Email", MySqlDbType.VarChar);

                aP_username.Value = pUsername;
                aP_password.Value = pPassword;
                aP_email.Value = pEmail;

                p.Add(aP_username);
                p.Add(aP_password);
                p.Add(aP_email);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call addUser(@Username, @Password, @Email)", p.ToArray());

                return aDataSet.Tables[0].Rows[0]["Message"].ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string updatePlayerProfile(int pPlayerId, string pUsername, string pPassword, string pEmail, bool pLockedOut, bool pBanned)
        {
            try
            {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var aP_playerId = new MySqlParameter("@PlayerId", MySqlDbType.Int32);
                var aP_username = new MySqlParameter("@Username", MySqlDbType.VarChar);
                var aP_password = new MySqlParameter("@Password", MySqlDbType.VarChar);
                var aP_email = new MySqlParameter("@Email", MySqlDbType.VarChar);
                var aP_lockedOut = new MySqlParameter("@LockedOut", MySqlDbType.Bit);
                var aP_banned = new MySqlParameter("@Banned", MySqlDbType.Bit);

                aP_playerId.Value = pPlayerId;
                aP_username.Value = pUsername;
                aP_password.Value = pPassword;
                aP_email.Value = pEmail;
                aP_lockedOut.Value = pLockedOut;
                aP_banned.Value = pBanned;

                p.Add(aP_playerId);
                p.Add(aP_username);
                p.Add(aP_password);
                p.Add(aP_email);
                p.Add(aP_lockedOut);
                p.Add(aP_banned);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call updatePlayerProfile(@PlayerId, @Username, @Password, @Email, @LockedOut, @Banned)", p.ToArray());

                return (aDataSet.Tables[0].Rows[0])["Message"].ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }   

        public string deletePlayer(int pPlayerId)
        {
            try
            {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var aP_playerId = new MySqlParameter("@PlayerId", MySqlDbType.Int32);
                aP_playerId.Value = pPlayerId;

                p.Add(aP_playerId);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call deletePlayer(@PlayerId)", p.ToArray());

                return (aDataSet.Tables[0].Rows[0])["Message"].ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string deleteGame(int pGameId)
        {
            try
            {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var aP_gameId = new MySqlParameter("@GameId", MySqlDbType.Int32);
                aP_gameId.Value = pGameId;

                p.Add(aP_gameId);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call deleteGame(@GameId)", p.ToArray());

                return (aDataSet.Tables[0].Rows[0])["Message"].ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

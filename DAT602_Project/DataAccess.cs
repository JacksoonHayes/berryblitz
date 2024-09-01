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

        public string AddUserName(string pUserName)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
            aP.Value = pUserName;
            p.Add(aP);


            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call AddUserName(@UserName)", p.ToArray());

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> lcPlayers = new List<Player>();

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetAllPlayers()");
            lcPlayers = (from aResult in
                                    System.Data.DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                         select
                            new Player
                            {
                                username = aResult["UserName"].ToString(),
                                score = Convert.ToInt32(aResult["score"]),
                            }).ToList();
            return lcPlayers;
        }
    }
}

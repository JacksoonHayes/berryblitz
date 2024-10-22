using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Project
{
    internal class LoginDAO : DataAccess
    {
        public string loginUser(string pUsername, string pPassword)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP_username = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
            var aP_password = new MySqlParameter("@Password", MySqlDbType.VarChar, 50);

            aP_username.Value = pUsername;
            aP_password.Value = pPassword;

            p.Add(aP_username);
            p.Add(aP_password);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call loginUser(@UserName, @Password)", p.ToArray());
            return (aDataSet.Tables[0].Rows[0])["Message"].ToString();
        }

        public string registerUser(string pUsername, string pPassword, string pEmail)
        {

            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP_username = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
            var aP_password = new MySqlParameter("@Password", MySqlDbType.VarChar, 50);
            var aP_email = new MySqlParameter("@Email", MySqlDbType.VarChar, 100);

            aP_username.Value = pUsername;
            aP_password.Value = pPassword;
            aP_email.Value = pEmail;

            p.Add(aP_username);
            p.Add(aP_password);
            p.Add(aP_email);


            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call registerUser(@UserName, @Password, @Email)", p.ToArray());
            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }
    }
}

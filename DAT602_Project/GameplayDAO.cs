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
        public string CreateGame()
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP_startTime = new MySqlParameter("@StartTime", MySqlDbType.Time);

            aP_startTime.Value = DateTime.Now.TimeOfDay;

            p.Add(aP_startTime);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call CreateGame(@StartTime)", p.ToArray());

            return (aDataSet.Tables[0].Rows[0])["Message"].ToString();
        }

    }
}

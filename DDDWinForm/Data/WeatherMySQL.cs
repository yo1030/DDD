using DDDWinForm.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDWinForm.Data
{
    public static class WeatherMySQL
    {
        public static DataTable GetLatest(int areaId)
        {
            string sql = $@"SELECT DataDate,
Conditions,
Temperature
FROM weather
WHERE AreaId={areaId}
ORDER BY DataDate DESC
LIMIT 1;";

            DataTable dt = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(CommonConst.connectionString))
            {
                connection.Open();	// 接続
                Console.WriteLine("MySQLに接続しました！");

                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
    }
}

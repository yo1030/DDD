using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.MySQL
{
    public class WeatherMySQL : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            string sql = $@"SELECT DataDate,
Conditions,
Temperature
FROM weather
WHERE AreaId={areaId}
ORDER BY DataDate DESC
LIMIT 1;";

            using (MySqlConnection connection = new MySqlConnection(MySQLHealper.connectionString))
            {
                connection.Open();	// 接続
                Console.WriteLine("MySQLに接続しました！");

                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new WeatherEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Conditions"]),
                            Convert.ToSingle(reader["Temperature"])
                        );
                    }
                }
            }
            return null;
        }
    }
}

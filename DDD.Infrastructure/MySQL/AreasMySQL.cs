using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DDD.Infrastructure.MySQL
{
    public sealed class AreasMySQL : IAreasRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            string sql = $@"
SELECT AreaId,
       AreaName
FROM Areas;";

            var result = new List<AreaEntity>();
            using (MySqlConnection connection = new MySqlConnection(MySQLHealper.connectionString))
            {
                connection.Open();	// 接続
                Console.WriteLine("MySQLに接続しました！");

                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(
                            new AreaEntity(
                                Convert.ToInt32(reader["AreaId"]),
                                Convert.ToString(reader["AreaName"])));
                    }
                }
            }
            return result.AsReadOnly();
        }
    }
}

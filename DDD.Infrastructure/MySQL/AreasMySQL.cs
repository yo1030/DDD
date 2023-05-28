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

            //return MySQLHealper.Query<AreaEntity>(sql, CreateEntity);
            //return MySQLHealper.Query(sql, CreateEntity);
            return MySQLHealper.Query(sql,
                reader =>
                {
                    return new AreaEntity(
                        Convert.ToInt32(reader["AreaId"]),
                        Convert.ToString(reader["AreaName"]));
                });
        }

        private AreaEntity CreateEntity(MySqlDataReader reader)
        {
            return new AreaEntity(Convert.ToInt32(reader["AreaId"]),
                                  Convert.ToString(reader["AreaName"]));
        }
    }
}

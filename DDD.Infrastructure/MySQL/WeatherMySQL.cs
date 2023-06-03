using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
WHERE AreaId=@areaId
ORDER BY DataDate DESC
LIMIT 1;";

            return MySQLHealper.QuerySingle(
                sql,
                new List<MySqlParameter>
                {
                    new MySqlParameter("areaId", areaId)
                }.ToArray(),
                reader =>
                {
                    return new WeatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Conditions"]),
                            Convert.ToSingle(reader["Temperature"]));
                },
                null);
        }
        public IReadOnlyList<WeatherEntity> GetData()
        {
            throw new NotImplementedException();
        }
    }
}

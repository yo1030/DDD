using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
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
            string sql = @"
select
    A.AreaId,
    IFNULL(B.AreaName, AreaName) as AreaName,
    A.DataDate,
    A.Conditions,
    A.Temperature
from Weather A
left outer join Areas B
on A.AreaId = B.AreaId;
";
            return MySQLHealper.Query(sql,
                reader =>
                {
                    return new WeatherEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToString(reader["AreaName"]),
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Conditions"]),
                            Convert.ToSingle(reader["Temperature"]));
                });
        }

        public void Save(WeatherEntity weather)
        {
            string insert = @"
insert into Weather
(AreaId, DataDate, Conditions, Temperature)
values
(@AreaId, @DataDate, @Conditions, @Temperature);
";
            string update = @"
update Weather
set Conditions = @Conditions,
	Temperature = @Temperature
where AreaId = @AreaId
and DataDate = @DataDate;
";
            var args = new List<MySqlParameter>
            {
                new MySqlParameter("@AreaId", weather.AreaId.Value),
                new MySqlParameter("@DataDate", weather.DataDate),
                new MySqlParameter("@Conditions", weather.Conditions.Value),
                new MySqlParameter("@Temperature", weather.Temperature.Value),
            };

            MySQLHealper.Execute(insert, update, args.ToArray());
        }
    }
}

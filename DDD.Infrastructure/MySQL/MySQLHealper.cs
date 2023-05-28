using DDD.Domain.Entities;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.MySQL
{
    internal class MySQLHealper
    {
        // MySQLへの接続情報
        internal readonly static string server = "localhost";
        internal readonly static string database = "ddd";
        internal readonly static string user = "y_ogihara";
        internal readonly static string pass = "tEKjUXbdztd5@";
        internal readonly static int port = 3306;
        internal readonly static string connectionString = string.Format("Server={0};Database={1};User={2};Password={3};Port={4}", server, database, user, pass, port);

        internal static IReadOnlyList<T> Query<T>(
            string sql,
            Func<MySqlDataReader, T> createEntity)
        {
            return Query<T>(sql, null, createEntity);
        }
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            MySqlParameter[] parameters,
            Func<MySqlDataReader, T> createEntity)
        {
            List<T> result = new List<T>();
            using (MySqlConnection connection = new MySqlConnection(MySQLHealper.connectionString))
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                connection.Open();
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(createEntity(reader));
                    }
                }
                return result;
            }
        }

        internal static T QuerySingle<T>(
            string sql,
            Func<MySqlDataReader, T> createEntity,
            T nullEntity)
        {
            return QuerySingle<T>(sql, null, createEntity, nullEntity);
        }

            internal static T QuerySingle<T>(
            string sql,
            MySqlParameter[] parameters,
            Func<MySqlDataReader, T> createEntity,
            T nullEntity)
        {
            using (MySqlConnection connection = new MySqlConnection(MySQLHealper.connectionString))
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                connection.Open();
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return createEntity(reader);
                    }
                }
                return nullEntity;
            }
        }
    }
}

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
    }
}

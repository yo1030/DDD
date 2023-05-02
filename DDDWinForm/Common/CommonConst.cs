using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDWinForm.Common
{
    public static class CommonConst
    {
        public const string TemperatureUnitName = "℃";
        public const int TemperatureDecimalPoint = 2;

        // MySQLへの接続情報
        private readonly static string server = "localhost";
        private readonly static string database = "ddd";
        private readonly static string user = "y_ogihara";
        private readonly static string pass = "tEKjUXbdztd5@";
        private readonly static int port = 3306;
        public readonly static string connectionString = string.Format("Server={0};Database={1};User={2};Password={3};Port={4}", server, database, user, pass, port);

    }
}

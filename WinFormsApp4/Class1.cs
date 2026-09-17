using System;
using MySql.Data.MySqlClient;

namespace WinFormsApp4
{
    public static class DatabaseContext
    {
        private static string connectionString = "Server=192.168.227.14;Database=lokteva_iliasova_ls41;Uid=user04;Pwd=User04!Pass;Charset=utf8;SslMode=None;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}

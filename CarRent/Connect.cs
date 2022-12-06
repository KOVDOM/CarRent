using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CarRent
{
    public class Connect
    {
        public MySqlConnection conn;

        string srv = "localhost";
        string db = "rent";
        string usr = "root";
        string pwd = "";

        public Connect()
        {
            string connectionString = "SERVER=" + srv + ";" + "DATABASE=" + db + ";" + "UID=" +usr+";"+"PASSWORD="  + pwd + ";" + "SslMode=None;";
            conn = new MySqlConnection(connectionString);

            conn.Open();

        }
    }
}
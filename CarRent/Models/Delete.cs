using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using CarRent;

namespace CarRent.Models
{
    public class Delete
    {
        Connect c = new Connect();
        public int DeleteCar(Car cardata)
        {
            try
            {
                string qry = "DELETE FROM cardata WHERE Id=@Id;";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.conn;
                cmd.Parameters.AddWithValue("@Id", cardata.Id);
                cmd.CommandText = qry;

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
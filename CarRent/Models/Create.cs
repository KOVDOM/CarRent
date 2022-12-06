using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRent;

namespace CarRent.Models
{
    public class Create
    {
        Connect c = new Connect();
        public int NewCar(Car cardata)
        {
            try
            {
                string qry = "INSERT INTO `cardata`(`CarMake`, `CarModel`, `CarYear`, `Color`, `CarVin`) VALUES (@CarMake,@CarModel,@CarYear,@Color,@CarVin);";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.conn;
                cmd.Parameters.AddWithValue("@CarMake", cardata.CarMake);
                cmd.Parameters.AddWithValue("@CarModel", cardata.CarModel);
                cmd.Parameters.AddWithValue("@CarYear", cardata.CarYear);
                cmd.Parameters.AddWithValue("@Color", cardata.Color);
                cmd.Parameters.AddWithValue("@CarVin", cardata.CarVin);
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
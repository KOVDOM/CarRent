using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using CarRent;
using MySql.Data.MySqlClient;

namespace CarRent.Models
{
    public class Select
    {
        Connect c=new Connect();
        public string Selectcar(string carname)
        {
            try
            {
                string qry = "SELECT * FROM cardata WHERE CarMake=@CarMake;";
                MySqlCommand cmd = new MySqlCommand(qry);
                cmd.Connection = c.conn;
                cmd.Parameters.AddWithValue("@CarMake", carname);
                cmd.CommandText = qry;
                Car car = new Car();
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    car.Id = dr.GetInt32("Id");
                    car.CarMake = dr.GetString("CarMake");
                    car.CarModel = dr.GetString("CarModel");
                    car.CarYear = dr.GetInt32("CarYear");
                    car.Color = dr.GetString("Color");
                    car.CarVin = dr.GetString("CarVin");
                }

                return "Id: " + car.Id + " Carname: " + car.CarMake + " Carmodel: " + car.CarModel + " CarYear: " + car.CarYear + " Color: " + car.Color + " CarVin: " + car.CarVin;
            }
            catch (Exception)
            {
                Car ca = new Car();
                ca.Id = 0;
                return "Hiba az adatbázis művelet során!";
            }
        }
    }
}
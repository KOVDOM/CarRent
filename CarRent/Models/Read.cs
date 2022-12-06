using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Web;
using System.Web.Script.Services;
using CarRent;

namespace CarRent.Models
{
    public class Read
    {
        Connect c=new Connect();
        public string authentical(int Id)
        {
            try
            {
                string qry = "SELECT * FROM cardata;";
                MySqlCommand cmd = new MySqlCommand(qry);
                cmd.Connection = c.conn;
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
                Car car = new Car();
                car.Id = 0;
                return "Hiba az adatbázis művelet során!";
            }
        }
    }
}
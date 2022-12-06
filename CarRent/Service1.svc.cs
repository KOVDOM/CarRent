using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CarRent.Models;
using MySql.Data.MySqlClient;

namespace CarRent
{
    public class Service1 : IService1
    {
        List<Car> carList= new List<Car>();
        public string delCar(Car cardata)
        {
            Delete d=new Delete();
            if (d.DeleteCar(cardata)>0)
            {
                return "Sikeres törlés!";
            }
            else
            {
                return "Hiba a törlés művelet során!";
            }
        }

        public string getCar(Car cardata)
        {
            Read r=new Read();
            return r.authentical(cardata.Id);
        }

        public string getCarmake(Car cardata)
        {
           Select s=new Select();
            return s.Selectcar(cardata.CarMake);
        }

        Connect c= new Connect();
        public List<Car> getList()
        {
            string qry= "SELECT * FROM cardata;";
            MySqlCommand cmd = new MySqlCommand(qry);
            cmd.Connection = c.conn;
            cmd.CommandText = qry;
            Car car = new Car();
            MySqlDataReader dr = cmd.ExecuteReader();
            Car ca=new Car();
            if (dr.HasRows)
            {
                dr.Read();
                ca.CarMake=ca.CarMake.ToString();
                ca.CarModel = ca.CarModel.ToString();
                ca.CarYear = int.Parse(ca.CarYear.ToString());
                ca.Color=ca.Color.ToString();
                ca.CarVin=ca.CarVin.ToString();
                carList.Add(ca);
            }
             return carList;
            
        }

        public string modCar(Car cardata)
        {
            Update u=new Update();
            if (u.modifyCar(cardata) > 0)
            {
                return "Sikeres adatmodósítás!";
            }
            else
            {
                return "Hiba az adatművelet során!";
            }
        }

        public string newCar(Car cardata)
        {
            Create cr = new Create();
            if (cr.NewCar(cardata) > 0)
            {
                return "Sikeres adatfelvitel!";
            }
            else
            {
                return "Hiba az adatfelvitel során!";
            }
        }
    }
}

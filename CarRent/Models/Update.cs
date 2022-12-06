using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Web;
using System.Web.Script.Services;
using MySql.Data.MySqlClient;
using CarRent;

namespace CarRent.Models
{
    public class Update
    {
        Connect c=new Connect();
        public int modifyCar(Car cardata) 
        {
            try
            {
                string qry = "UPDATE cardata SET `Color`=@Color WHERE Id=@Id;";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.conn;
                cmd.Parameters.AddWithValue("@Color", cardata.Color);
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
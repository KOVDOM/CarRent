using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace CarRent
{
    [ServiceContract]
    public class Car
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CarMake { get; set; }
        [DataMember]
        public string CarModel { get; set; }
        [DataMember]
        public int CarYear { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string CarVin { get; set; }
    }
}
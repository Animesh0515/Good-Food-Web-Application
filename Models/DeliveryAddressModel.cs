using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFoodCompany.Models
{
    public class DeliveryAddressModel
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int  ZipCode { get; set; }
    }
}
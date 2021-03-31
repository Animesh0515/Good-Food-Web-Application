using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFoodCompany.Models
{
    public class CustomerDetailModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public Int64 PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }
        public bool? Enabled { get; set; } = false;
    }
}
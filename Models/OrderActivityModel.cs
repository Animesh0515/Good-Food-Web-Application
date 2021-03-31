using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFoodCompany.Models
{
    public class OrderActivityModel
    {
        public int ID { get; set; }
        public string RestaurantName { get; set; }
        public string  Address { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string DishName { get; set; }
        public int  OrderUnit { get; set; }
        public int LineTotal { get; set; }
        public string DeliveryStatus { get; set; }
        public int Month { get; set; }

    }
}
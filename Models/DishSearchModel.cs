using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFoodCompany.Models
{
    public class DishSearchModel
    {
        public int ID { get; set; }
        public string DishName { get; set; }
        public string RestaurantName { get; set; }
        public string  Address { get; set; }
        public string ContactNo { get; set; }
        public string Website { get; set; }
        public decimal DishRate { get; set; }
        public int LoyaltyPoint { get; set; }
    }
}
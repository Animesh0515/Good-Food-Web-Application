using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFoodCompany.Models
{
    public class DishDetailModel
    {
        public int ID { get; set; }
        public string DishCode { get; set; }
        public string DishName { get; set; }
        public string localName { get; set; }
    }
}
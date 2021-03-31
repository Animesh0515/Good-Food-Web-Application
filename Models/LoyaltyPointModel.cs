using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFoodCompany.Models
{
    public class LoyaltyPointModel
    {
        public int Code { get; set; }
        public int LoyaltyPoint { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
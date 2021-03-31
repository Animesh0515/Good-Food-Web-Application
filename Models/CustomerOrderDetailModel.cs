using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFoodCompany.Models
{
    public class CustomerOrderDetailModel
    {
        public string CustomerName { get; set; }
        public List<OrderDetail> orderDetails { get; set; } = new List<OrderDetail>();
        
    }
    public class OrderDetail
    {
        public string OrderNumber { get; set; }
        public string DishCode { get; set; }
        public string DishName { get; set; }
        public string LocalName { get; set; }
        public int Orderunit { get; set; }
        public decimal LineTotal { get; set; }
        public decimal TotalAmount { get; set; }
        public int LoyaltyPoint { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
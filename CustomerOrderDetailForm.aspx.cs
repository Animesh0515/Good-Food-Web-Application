using GoodFoodCompany.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodFoodCompany
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        string connectionString = OracleConnectionModel.ConnectionString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(! IsPostBack)
            {
                dgvcustomerorderdetail.DataSource = null;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerOrderDetailModel customerOrderDetail = new CustomerOrderDetailModel();
            int i=0;
            
            customerOrderDetail.CustomerName = txtcustomername.Text.ToString();
            OracleConnection conn = new OracleConnection(connectionString);
            string query = "select  " +
                "orders.ordernumber," +
                " odetails.OrderUnit," +
                " odetails.linetotal," +
                "  bill.OrderAmount, " +
                "dish.dish_code," +
                " dish.dishname, " +
                "dish.local_or_another_name," +
                "daddress.address_name," +
                "lpoint.point " +
                "from customer" +
                " LEFT OUTER JOIN " +
                "customerorderbill bill" +
                "   ON" +
                " customer.Customer_ID = bill.customer_id " +
                "left join " +
                "orders on" +
                " bill.ordernumber = orders.ordernumber" +
                " left join" +
                " orderdetail odetails on orders.ordernumber = odetails.ordernumber" +
                " left join" +
                " dish on " +
                "odetails.dish_id = dish.dish_id " +
                "left join" +
                " deliveryaddress daddress on" +
                " daddress.address_id = orders.address_id" +
                " left join " +
                "loyaltypoint lpoint on" +
                " lpoint.loyaltypoint_code = odetails.loyaltypoint_code" +
                "  where Upper(customer.fullname)=Upper('"+ customerOrderDetail.CustomerName+"') ";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                OrderDetail order = new OrderDetail();
                order.OrderNumber = reader["OrderNumber"].ToString();
                order.DishCode = reader["Dish_Code"].ToString();
                order.LineTotal = Convert.ToDecimal(reader["LineTotal"].ToString());
                order.TotalAmount = Convert.ToDecimal(reader["OrderAmount"].ToString());
                order.DishName = reader["DishName"].ToString();
                order.LocalName = reader["Local_or_Another_Name"].ToString();
                order.Orderunit = int.Parse(reader["Orderunit"].ToString());
                if(int.TryParse(reader["Point"].ToString(), out(i)))
                {
                    order.LoyaltyPoint = i;
                }
                
                
                order.DeliveryAddress = reader["Address_Name"].ToString();
                customerOrderDetail.orderDetails.Add(order);


                
            }
            conn.Close();


            dgvcustomerorderdetail.DataSource = null;
            dgvcustomerorderdetail.DataSource = customerOrderDetail.orderDetails;
            dgvcustomerorderdetail.DataBind();
        }
    }
}
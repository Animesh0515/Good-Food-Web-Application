using GoodFoodCompany.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace GoodFoodCompany
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        string connectionString = OracleConnectionModel.ConnectionString();
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.bindgrid();
                lblmonthwarn.Visible = false;
                lblmonthamount.Visible = false;
                lblmonthbilltext.Visible = false;

                //this.bindddl();
                //System.Web.UI.Control myControl1 = FindControl("TextBox2"); ;
            }
            //ddlmonths.SelectedIndex = -1;
        }
        private void bindgrid()
        {
            
            
            List<OrderActivityModel> orderlst = new List<OrderActivityModel>();
            string customername = txtcustomername.Text.ToString();
            OracleConnection conn = new OracleConnection(connectionString);
            string query = "select fullname," +
                            " ordernumber," +
                            " order_datetime, " +
                            "status," +
                            " restaurant_id," +
                            " restaurant_name," +
                            " address, " +
                            "  dishname," +
                            " orderunit, " +
                            "linetotal" +
                            "  from " +
                            "(select cs.fullname," +
                            " od.ordernumber," +
                            " od.order_datetime," +
                            " od.status," +
                            " rs.restaurant_id," +
                            " rs.restaurant_name," +
                            " rs.address, " +
                            "odd.orderunit," +
                            " odd.linetotal," +
                            " ds.dish_code," +
                            " ds.dishname " +
                            "from customer cs " +
                            "left join " +
                            "customerorderbill csb on" +
                            " cs.customer_id=csb.customer_id" +
                            " left join " +
                            "orders od on " +
                            "csb.ordernumber=od.ordernumber " +
                            "left join restaurant rs on" +
                            " od.restaurant_id=rs.restaurant_id " +
                            "left join orderdetail odd on" +
                            " od.ordernumber=odd.ordernumber" +
                            " left join dish ds on" +
                            " odd.dish_id=ds.dish_id )";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                OrderActivityModel dish = new OrderActivityModel();
                if (int.TryParse(reader["Restaurant_Id"].ToString(), out (count)))
                {
                    dish.ID = Convert.ToInt32(reader["Restaurant_ID"].ToString());
                    dish.RestaurantName = reader["Restaurant_Name"].ToString();
                    dish.Address = reader["Address"].ToString();
                    dish.OrderNumber = reader["Ordernumber"].ToString();
                    dish.OrderDate = reader["Order_Datetime"].ToString();
                    dish.DishName = reader["DishName"].ToString();
                    dish.OrderUnit = int.Parse(reader["OrderUnit"].ToString());
                    dish.LineTotal = int.Parse(reader["linetotal"].ToString());
                    dish.DeliveryStatus = reader["status"].ToString();
                    
                    orderlst.Add(dish);

                }

            }
            conn.Close();


            dgvorderactivity.DataSource = null;
            dgvorderactivity.DataSource = orderlst;
            dgvorderactivity.DataBind();
        }
        private void bindddl()
        {
            List<OrderActivityModel> months = new List<OrderActivityModel>();
            OrderActivityModel orderActivity = new OrderActivityModel();
            OracleConnection conn = new OracleConnection(connectionString);
            string query = "select Distinct TO_CHAR(order_datetime, 'MM') ordermonth from orders";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orderActivity.Month = int.Parse(reader["Ordermonth"].ToString());
                months.Add(orderActivity);

            }
            ddlmonths.DataValueField = "Month";
            ddlmonths.DataTextField = "Month";
            ddlmonths.DataSource = months;
            ddlmonths.DataBind();
            //orderActivity = months.GroupBy(x => x.Month).Select(g=>g.First());

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //int month = 3;
            int Monthtotal = 0;
            int month = int.Parse(ddlmonths.SelectedValue.ToString());
            string customer = txtcustomername.Text;
            List<OrderActivityModel> lst = new List<OrderActivityModel>();
            OracleConnection conn = new OracleConnection(connectionString);
            string query = "select fullname," +
                            " ordernumber," +
                            " order_datetime, " +
                            "status," +
                            " restaurant_id," +
                            " restaurant_name," +
                            " address, " +
                            "  dishname," +
                            " orderunit, " +
                            "linetotal" +
                            "  from " +
                            "(select cs.fullname," +
                            " od.ordernumber," +
                            " od.order_datetime," +
                            " od.status," +
                            " rs.restaurant_id," +
                            " rs.restaurant_name," +
                            " rs.address, " +
                            "odd.orderunit," +
                            " odd.linetotal," +
                            " ds.dish_code," +
                            " ds.dishname " +
                            "from customer cs " +
                            "left join " +
                            "customerorderbill csb on" +
                            " cs.customer_id=csb.customer_id" +
                            " left join " +
                            "orders od on " +
                            "csb.ordernumber=od.ordernumber " +
                            "left join restaurant rs on" +
                            " od.restaurant_id=rs.restaurant_id " +
                            "left join orderdetail odd on" +
                            " od.ordernumber=odd.ordernumber" +
                            " left join dish ds on" +
                            " odd.dish_id=ds.dish_id where TO_CHAR(od.order_datetime, 'MM')='0"+month+"')where Upper(fullname)=Upper('"+customer+ "') and rownum<=5 order by (orderunit) desc";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                OrderActivityModel dishord = new OrderActivityModel();
                if (int.TryParse(reader["Restaurant_Id"].ToString(), out (count)))
                {
                    dishord.ID = Convert.ToInt32(reader["Restaurant_ID"].ToString());
                    dishord.RestaurantName = reader["Restaurant_Name"].ToString();
                    dishord.Address = reader["Address"].ToString();
                    dishord.OrderNumber = reader["Ordernumber"].ToString();
                    dishord.OrderDate = reader["Order_Datetime"].ToString();
                    dishord.DishName = reader["DishName"].ToString();
                    dishord.OrderUnit = int.Parse(reader["OrderUnit"].ToString());
                    dishord.LineTotal = int.Parse(reader["linetotal"].ToString());
                    dishord.DeliveryStatus = reader["status"].ToString();
                    Monthtotal += dishord.LineTotal;
                    lst.Add(dishord);

                }

            }
            
            dgvorderactivity.DataSource = null;
            dgvorderactivity.DataSource = lst;
            dgvorderactivity.DataBind();
            ddlmonths.DataBind();
            lblmonthbilltext.Text = "Total Bill of Month:";
            lblmonthamount.Text = Monthtotal.ToString();
            lblmonthamount.Visible = true;
            lblmonthbilltext.Visible = true;

        }

        
    }
}


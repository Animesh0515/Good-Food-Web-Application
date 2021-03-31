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
    public partial class WebForm8 : System.Web.UI.Page
    {
        string connectionString = OracleConnectionModel.ConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvrestaurantdish.DataSource = null;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            int i = 0;
            List<DishSearchModel> dishlst = new List<DishSearchModel>();
            string dishname = txtdishname.Text.ToString();
            OracleConnection conn = new OracleConnection(connectionString);
            string query = "select restaurant.restaurant_id," +
                " restaurant.restaurant_name," +
                "restaurant.address, " +
                "restaurant.contact_no," +
                " restaurant.website, " +
                "rate.dishrate," +
                " lp.point " +
                "from restaurant" +
                " left join restaurantdishrate rate on " +
                "restaurant.restaurant_id=rate.restaurant_id  " +
                "left join dish on rate.dish_id=dish.dish_id " +
                " left join loyaltypoint lp on " +
                "dish.loyaltypoint_code=lp.loyaltypoint_code " +
                "where Upper(dish.dishname)=Upper('"+ dishname + "')";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DishSearchModel dish = new DishSearchModel();
                dish.ID = int.Parse(reader["Restaurant_ID"].ToString());
                dish.RestaurantName = reader["Restaurant_Name"].ToString();
                dish.Address = reader["Address"].ToString();
                dish.ContactNo = reader["Contact_No"].ToString();
                dish.Website = reader["Website"].ToString();
                dish.DishRate = int.Parse(reader["DishRate"].ToString());
                dish.LoyaltyPoint = int.Parse(reader["Point"].ToString());

                dishlst.Add(dish);



            }
            conn.Close();


            dgvrestaurantdish.DataSource = null;
            dgvrestaurantdish.DataSource = dishlst;
            dgvrestaurantdish.DataBind();
        }
    }
}
    

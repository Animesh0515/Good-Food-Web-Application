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
    public partial class GridDemo : System.Web.UI.Page
    {
        string connectionString = OracleConnectionModel.ConnectionString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                this.bindGrid();
            }
        }
        private void bindGrid()
        {
            List<RestaurantDetailModel> restaurantslst = new List<RestaurantDetailModel>();
            OracleConnection conn = new OracleConnection(connectionString);
            string query = "Select * from restaurant";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                RestaurantDetailModel restaurant = new RestaurantDetailModel();
                restaurant.ID = int.Parse(reader["Restaurant_ID"].ToString());
                restaurant.RestaurantName = reader["Restaurant_Name"].ToString();
                restaurant.Address = reader["Address"].ToString();
                restaurant.ContactNo = reader["Contact_No"].ToString();
                restaurant.Website = reader["Website"].ToString();
                restaurantslst.Add(restaurant);
            }
            conn.Close();


            GridView1.DataSource = null;
            GridView1.DataSource = restaurantslst;
            GridView1.DataBind();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            
            TextBox TextBox1 = (TextBox)GridView1.Rows[e.NewEditIndex].FindControl("TextBox1");
            TextBox1.Enabled = false;
            this.bindGrid();

        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RestaurantDetailModel restaurant = new RestaurantDetailModel();
            GridViewRow row = GridView1.Rows[e.RowIndex];
            restaurant.ID = int.Parse((row.Cells[1].Controls[0] as TextBox).Text);
            //dish.ID = Convert.ToInt32(dgvDishDetail.DataKeys[e.RowIndex].Values[0]);
            restaurant.RestaurantName = (row.Cells[2].Controls[0] as TextBox).Text;
            restaurant.Address = (row.Cells[3].Controls[0] as TextBox).Text;
            restaurant.ContactNo = (row.Cells[4].Controls[0] as TextBox).Text;
            restaurant.Website = (row.Cells[5].Controls[0] as TextBox).Text;



            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("update restaurant set Restaurant_Name = '" + restaurant.RestaurantName + "',Address = '" + restaurant.Address + "',Contact_No='" + restaurant.ContactNo + "',Website='" + restaurant.Website + "' where Restaurant_ID = " + restaurant.ID))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }

            GridView1.EditIndex = -1;
            this.bindGrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.bindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Restaurant WHERE ID =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.bindGrid();
        }
    }
}
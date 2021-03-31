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
    public partial class WebForm3 : System.Web.UI.Page
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


            dgvrestaurantdetail.DataSource = null;
            dgvrestaurantdetail.DataSource = restaurantslst;
            dgvrestaurantdetail.DataBind();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvrestaurantdetail.EditIndex = e.NewEditIndex;
            this.bindGrid();
           
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RestaurantDetailModel restaurant = new RestaurantDetailModel();
            GridViewRow row = dgvrestaurantdetail.Rows[e.RowIndex];
            restaurant.ID = int.Parse((row.Cells[1].Controls[0] as TextBox).Text);
            //dish.ID = Convert.ToInt32(dgvDishDetail.DataKeys[e.RowIndex].Values[0]);
            restaurant.RestaurantName = (row.Cells[2].Controls[0] as TextBox).Text;
            restaurant.Address = (row.Cells[3].Controls[0] as TextBox).Text;
            restaurant.ContactNo = (row.Cells[4].Controls[0] as TextBox).Text;
            restaurant.Website = (row.Cells[5].Controls[0] as TextBox).Text;



            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("update restaurant set Restaurant_Name = '" + restaurant.RestaurantName + "',Address = '" + restaurant.Address + "',Contact_No='" + restaurant.ContactNo + "',Website='"+restaurant.Website+"' where Restaurant_ID = " + restaurant.ID))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }

            dgvrestaurantdetail.EditIndex = -1;
            this.bindGrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            dgvrestaurantdetail.EditIndex = -1;
            this.bindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvrestaurantdetail.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(dgvrestaurantdetail.DataKeys[e.RowIndex].Values[0]);

            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Restaurant WHERE RESTAURANT_ID =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.bindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            RestaurantDetailModel restaurant = new RestaurantDetailModel();
            restaurant.RestaurantName = txtrestaurantname.Text.ToString();
            restaurant.Address = txtaddress.Text.ToString();
            restaurant.ContactNo = txtcontactno.Text.ToString();
            restaurant.Website = txtwebsite.Text.ToString();


            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("Insert into restaurant(Restaurant_Name, Address, Contact_No, Website)Values('" + restaurant.RestaurantName + "','" + restaurant.Address + "','" + restaurant.ContactNo + "','"+ restaurant.Website+"')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtrestaurantname.Text = "";
                    txtaddress.Text = "";
                    txtcontactno.Text = "";
                    txtwebsite.Text = "";


                }



                this.bindGrid();
            }
        }



        
    }
}

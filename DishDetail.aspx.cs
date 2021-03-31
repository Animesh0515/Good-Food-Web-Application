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
    public partial class WebForm2 : System.Web.UI.Page
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
            List<DishDetailModel> dishlst = new List<DishDetailModel>();
            OracleConnection conn = new OracleConnection(connectionString);
            string query = "Select * from dish";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                DishDetailModel dish = new DishDetailModel();
                dish.ID = int.Parse(reader["Dish_ID"].ToString());
                dish.DishCode = reader["Dish_code"].ToString();
                dish.DishName = reader["DishName"].ToString();
                dish.localName = reader["local_or_Another_Name"].ToString();
                dishlst.Add(dish);
            }
            conn.Close();

            List<int> ddlst = new List<int>();
            ddlst.Add(1);
            for (int i = 0; i < ddlst.Count; i++)
            {
                //ddlBooks.Items.Add(ddlst[i].ToString());
            }
            //ddlBooks.DataTextField = "";
            //ddlBooks.DataValueField
                //ddlBooks.DataSource=ddlst;
            dgvDishDetail.DataSource = null;
            dgvDishDetail.DataSource = dishlst;
            dgvDishDetail.DataBind();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvDishDetail.EditIndex = e.NewEditIndex;
            //dgvDishDetail.Rows[e.NewEditIndex].ReadOnly = true;
            // dgvDishDetail.Rows[e.NewEditIndex].Enabled = false; ;
          
            this.bindGrid();
            //GridViewRow row = dgvDishDetail.Rows[e.NewEditIndex];

            //(row.Cells[1].Controls[0] as TextBox).Enabled = false;
            //dgvDishDetail
            ////TextBox TextBox1 = (TextBox)GridView1.Rows[e.NewEditIndex].FindControl("txtCustomer_Id");
            //TextBox1.Enabled = true;
            //TextBox txt = (TextBox)dgvDishDetail.Rows[e.NewEditIndex].FindControl("ID");
            //((BoundField)dgvDishDetail.Columns[0]).ReadOnly = true;
            //txt.ReadOnly = true;
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DishDetailModel dish = new DishDetailModel();
            //ID, Name, Gender, Qualification FROM Author
            GridViewRow row = dgvDishDetail.Rows[e.RowIndex];
            dish.ID = int.Parse(dgvDishDetail.DataKeys[e.RowIndex].Values[0].ToString());
            //dish.ID = Convert.ToInt32(dgvDishDetail.DataKeys[e.RowIndex].Values[0]);
            dish.DishCode = (row.Cells[2].Controls[0] as TextBox).Text;
            dish.DishName = (row.Cells[3].Controls[0] as TextBox).Text;
            dish.localName = (row.Cells[4].Controls[0] as TextBox).Text;


            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("update dish set Dish_Code = '" + dish.DishCode + "',DishName = '" + dish.DishName + "',Local_or_Another_Name='"+dish.localName+"' where Dish_ID = " + dish.ID))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    

                }
            }

            dgvDishDetail.EditIndex = -1;
            this.bindGrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            dgvDishDetail.EditIndex = -1;
            this.bindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvDishDetail.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(dgvDishDetail.DataKeys[e.RowIndex].Values[0]);

            using (OracleConnection con = new OracleConnection(connectionString)) 
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Dish WHERE Dish_ID =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.bindGrid();
        }

        

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            DishDetailModel dish = new DishDetailModel();
            dish.DishCode = txtdishcode.Text.ToString();
            dish.DishName = txtdishname.Text.ToString();
            dish.localName = txtlocalname.Text.ToString();


            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("Insert into dish(Dish_Code, DishName, Local_or_Another_Name)Values('" + dish.DishCode + "','" + dish.DishName + "','" + dish.localName + "')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    txtdishcode.Text = "";
                    txtdishname.Text = "";
                    txtlocalname.Text = "";

                }



                this.bindGrid();
                btnAdd.Attributes["onclick"] = "return confirm('Sucessfuully Added');";

            }
        }
    }
}

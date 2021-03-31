using GoodFoodCompany.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodFoodCompany
{
    public partial class WebForm6 : System.Web.UI.Page
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
            List<LoyaltyPointModel> loyaltypointslst = new List<LoyaltyPointModel>();
            OracleConnection conn = new OracleConnection(connectionString);
            string query = "Select * from loyaltypoint";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LoyaltyPointModel loyaltypoint = new LoyaltyPointModel();
                loyaltypoint.Code = int.Parse(reader["loyaltypoint_code"].ToString());
                loyaltypoint.LoyaltyPoint = int.Parse(reader["Point"].ToString());
                loyaltypoint.StartDate = reader["Start_Date"].ToString();
                loyaltypoint.EndDate = reader["End_Date"].ToString();


                loyaltypointslst.Add(loyaltypoint);
            }
            conn.Close();


            dgvloyaltypointdetail.DataSource = null;
            dgvloyaltypointdetail.DataSource = loyaltypointslst;
            dgvloyaltypointdetail.DataBind();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvloyaltypointdetail.EditIndex = e.NewEditIndex;

            this.bindGrid();

        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            LoyaltyPointModel loyaltypoint = new LoyaltyPointModel();
            GridViewRow row = dgvloyaltypointdetail.Rows[e.RowIndex];
             
            loyaltypoint.Code = Convert.ToInt32(dgvloyaltypointdetail.DataKeys[e.RowIndex].Values[0]);
            loyaltypoint.LoyaltyPoint = int.Parse((row.Cells[2].Controls[0] as TextBox).Text);
            loyaltypoint.StartDate = (row.Cells[3].Controls[0] as TextBox).Text;
            loyaltypoint.EndDate = (row.Cells[4].Controls[0] as TextBox).Text;





            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("update loyaltypoint set Point = '" + loyaltypoint.LoyaltyPoint + "',Start_Date = '" + loyaltypoint.StartDate + "',End_Date='" + loyaltypoint.EndDate + "' where loyaltypoint_Code = " + loyaltypoint.Code))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }

            dgvloyaltypointdetail.EditIndex = -1;
            this.bindGrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            dgvloyaltypointdetail.EditIndex = -1;
            this.bindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvloyaltypointdetail.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Code = Convert.ToInt32(dgvloyaltypointdetail.DataKeys[e.RowIndex].Values[0]);

            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM loyaltypoint WHERE loyaltypoint_Code =" + Code))
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
            LoyaltyPointModel loyaltypoint = new LoyaltyPointModel();
            loyaltypoint.LoyaltyPoint = int.Parse(txtloyaltypoint.Text.ToString());
            //DateTime startdt = DateTime.Parse(txtStartDate.Text.ToString());
            //string  date = startdt.ToString("MM-dd-yyyy hh:mm tt") ;
            //loyaltypoint.StartDate= DateTime.ParseExact(txtStartDate.Text.ToString(), "yy/MM/dd hh:mm AM", CultureInfo.InvariantCulture);
            loyaltypoint.StartDate = txtStartDate.Text.ToString();
            //loyaltypoint.StartDate = Convert.ToDateTime(txtStartDate.Text);
            //string startdateshift=loyaltypoint.StartDate.ToString("tt");
            //string am = String.Format("{tt}", loyaltypoint.StartDate);
            loyaltypoint.EndDate = txtEndDate.Text.ToString();
            //string enddateshift = loyaltypoint.EndDate.ToString("tt");



            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("Insert into loyaltypoint(Point, Start_Date, End_Date )Values('" + loyaltypoint.LoyaltyPoint + "',to_date('" + loyaltypoint.StartDate + "','mm-dd-yyyy hh:mi AM' ), to_date('" + loyaltypoint.EndDate + "','dd-mm-yyyy hh:mm AM'))"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtloyaltypoint.Text = "";
                    txtStartDate.Text = "";
                    txtEndDate.Text = "";



                }



                this.bindGrid();
            }

        }
    }
}


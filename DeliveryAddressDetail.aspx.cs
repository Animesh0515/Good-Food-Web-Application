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
    public partial class WebForm5 : System.Web.UI.Page
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
            List<DeliveryAddressModel> addressslst = new List<DeliveryAddressModel>();
            OracleConnection conn = new OracleConnection(connectionString);
            string query = "Select * from deliveryaddress";
            OracleCommand cmd = new OracleCommand(query, conn);
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DeliveryAddressModel address = new DeliveryAddressModel();
                address.ID = int.Parse(reader["address_ID"].ToString());
                address.Address = reader["address_Name"].ToString();
                address.Latitude = Convert.ToDecimal(reader["Latitude"].ToString());
                address.Longitude = Convert.ToDecimal(reader["Longitude"].ToString());
                address.ZipCode = int.Parse(reader["Zip_Code"].ToString());
                addressslst.Add(address);
            }
            conn.Close();


            dgvdeliveryaddress.DataSource = null;
            dgvdeliveryaddress.DataSource = addressslst;
            dgvdeliveryaddress.DataBind();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvdeliveryaddress.EditIndex = e.NewEditIndex;
            this.bindGrid();

        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DeliveryAddressModel address = new DeliveryAddressModel();
            GridViewRow row = dgvdeliveryaddress.Rows[e.RowIndex];
            address.ID = Convert.ToInt32(dgvdeliveryaddress.DataKeys[e.RowIndex].Values[0]);
            //dish.ID = Convert.ToInt32(dgvDishDetail.DataKeys[e.RowIndex].Values[0]);
            address.Address = (row.Cells[2].Controls[0] as TextBox).Text;
            address.Latitude = Convert.ToDecimal((row.Cells[3].Controls[0] as TextBox).Text);
            address.Longitude = Convert.ToDecimal((row.Cells[4].Controls[0] as TextBox).Text);
            address.ZipCode = int.Parse((row.Cells[5].Controls[0] as TextBox).Text);



            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("update deliveryaddress set address_Name = '" + address.Address + "',Latitude = '" + address.Latitude + "',Longitude='" + address.Longitude + "',Zip_Code='" + address.ZipCode + "' where address_ID = " + address.ID))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }

            dgvdeliveryaddress.EditIndex = -1;
            this.bindGrid();
        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            dgvdeliveryaddress.EditIndex = -1;
            this.bindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvdeliveryaddress.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(dgvdeliveryaddress.DataKeys[e.RowIndex].Values[0]);

            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM deliveryaddress WHERE ADDRESS_ID =" + ID))
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
            DeliveryAddressModel addressModel = new DeliveryAddressModel();
            addressModel.Address = txtaddressname.Text.ToString();
            addressModel.Latitude = Convert.ToDecimal(txtlatitude.Text.ToString());
            addressModel.Longitude = Convert.ToDecimal(txtlongitude.Text.ToString());
            addressModel.ZipCode = int.Parse(txtzipcode.Text.ToString());


            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("Insert into deliveryaddress(Address_Name, Latitude, Longitude, Zip_Code)Values('" + addressModel.Address + "','" + addressModel.Latitude + "','" + addressModel.Longitude + "'," + addressModel.ZipCode + ")"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtaddressname.Text = "";
                    txtlatitude.Text = "";
                    txtlongitude.Text = "";
                    txtzipcode.Text = "";


                }



                this.bindGrid();
            }
        }
    }
}


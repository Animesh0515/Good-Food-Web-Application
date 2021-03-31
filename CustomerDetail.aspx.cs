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
    public partial class WebForm4 : System.Web.UI.Page
    {
        string connectionString = OracleConnectionModel.ConnectionString();
        bool status = false;
        int index = 0;
        int counter=1;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.bindGrid();
            }
        }
 

           
            private void bindGrid()
            {
                List<CustomerDetailModel> customerslst = new List<CustomerDetailModel>();
                OracleConnection conn = new OracleConnection(connectionString);
                string query = "Select * from customer";
                OracleCommand cmd = new OracleCommand(query, conn);
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                if(counter==index)
                {
                    this.status = true;
                }
                    CustomerDetailModel customer = new CustomerDetailModel();
                    customer.ID = int.Parse(reader["Customer_ID"].ToString());
                    customer.CustomerName = reader["FullName"].ToString();
                    customer.EmailAddress = reader["Email"].ToString();
                    customer.PhoneNo = Convert.ToInt64(reader["Phone_No"].ToString());
                    customer.Address = reader["Address"].ToString();
                    customer.ImageURL = reader["IMAGEURL"].ToString();
                    customer.Enabled = status;
                    this.status = false;
                counter++;

                customerslst.Add(customer);
                }
                conn.Close();


                dgvCustomerdetail.DataSource = null;
                dgvCustomerdetail.DataSource = customerslst;
                dgvCustomerdetail.DataBind();
            }
            protected void OnRowEditing(object sender, GridViewEditEventArgs e)
            {
                dgvCustomerdetail.EditIndex = e.NewEditIndex;
            this.counter = 0;
            this.index= e.NewEditIndex;
            
            this.bindGrid();

            }

            protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                CustomerDetailModel customer = new CustomerDetailModel();
                GridViewRow row = dgvCustomerdetail.Rows[e.RowIndex];
                TextBox txtID = (TextBox)dgvCustomerdetail.Rows[e.RowIndex].FindControl("txtCustomerID");
                customer.ID = int.Parse(txtID.Text);
                TextBox txtCustomerName = (TextBox)dgvCustomerdetail.Rows[e.RowIndex].FindControl("txtCustomerName");
                 customer.CustomerName = txtCustomerName.Text;
                TextBox txtPhoneNo = (TextBox)dgvCustomerdetail.Rows[e.RowIndex].FindControl("txtPhoneNo");
                 customer.PhoneNo = long.Parse(txtPhoneNo.Text);
                TextBox txtEmail = (TextBox)dgvCustomerdetail.Rows[e.RowIndex].FindControl("txtEmail");
                customer.EmailAddress = txtEmail.Text;
                TextBox txtAddress = (TextBox)dgvCustomerdetail.Rows[e.RowIndex].FindControl("txtAddress");
                 customer.Address = txtAddress.Text;
               




            using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("update customer set FullName = '" + customer.CustomerName + "',Email = '" + customer.EmailAddress + "',Phone_No='" + customer.PhoneNo + "',Address='" + customer.Address + "' where customer_ID = " + customer.ID))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();



                    }
                }

                dgvCustomerdetail.EditIndex = -1;
                this.bindGrid();
            }
            protected void OnRowCancelingEdit(object sender, EventArgs e)
            {
                dgvCustomerdetail.EditIndex = -1;
                this.bindGrid();
            }
            protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != dgvCustomerdetail.EditIndex)
                {
                    (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
                }

            }
            protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            TextBox txtID = (TextBox)dgvCustomerdetail.Rows[e.RowIndex].FindControl("txtCustomerID");
            int ID = int.Parse(txtID.Text);

                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("DELETE FROM customer WHERE Customer_ID =" + ID))
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
            CustomerDetailModel customer = new CustomerDetailModel();
            customer.CustomerName = txtCustomerName.Text.ToString();
            customer.EmailAddress = txtEmail.Text.ToString();
            customer.PhoneNo = Convert.ToInt64(txtPhoneNo.Text.ToString());
            customer.Address = txtAddress.Text.ToString();


            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("Insert into customer(FullName, Email, Phone_No, Address)Values('" + customer.CustomerName + "','" + customer.EmailAddress + "','" + customer.PhoneNo + "','" + customer.Address + "')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtCustomerName.Text = "";
                    txtEmail.Text = "";
                    txtPhoneNo.Text = "";
                    txtAddress.Text = "";


                }



                this.bindGrid();
            }
        }





    }
    }



<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerDetail.aspx.cs" Inherits="GoodFoodCompany.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" >
            <div class="col-md-9" style="padding-left:390px; padding-bottom:20px">
 
                <div class="card">
                    <div class="card-body">
 
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Customer Details</h4>
                                    </center>
                            </div>
                        </div>
 
                        
 
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col-md-12">
                                <label>Customer Name</label>
                                <div class="form-group">

                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtCustomerName" runat="server" placeholder="Customer Name"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ID="RFVCustomerName" ControlToValidate="txtCustomerName" ErrorMessage="Please Enter the Customer Name" style="color: red; visibility: visible; font-size:small"/>--%>
            
                               
                                        
                                    </div>

                                </div>
                            </div>
 
                            <div class="col-md-12">
                                <label>Phone No</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPhoneNo" runat="server" placeholder="Phone No"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator runat="server" ID="RFVPhoneNo" ControlToValidate="txtPhoneNo" ErrorMessage="Please Enter the Phone No" style="color: red; visibility: visible; font-size:small"/>
                                            <%--<asp:RegularExpressionValidator runat="server" ID="revPhoneNo" ControlToValidate="txtPhoneNo"     ErrorMessage="Valid Phone No is required." ValidationExpression="^(([0-9]{10}))$" style="color: red; visibility: visible; font-size:small; padding-left:10px"/>--%>

                                    </div>
                                </div>
                            </div>
                              <div class="col-md-6">
                                <label>Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server" placeholder="Address"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ID="RFVAddress" ControlToValidate="txtAddress" ErrorMessage="Please Enter the Address" style="color: red; visibility: visible; font-size:small"/>--%>
                    
                                </div>
                            </div>
                             
                            <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
           <%--<asp:RequiredFieldValidator runat="server" ID="RFVEmail" ControlToValidate="txtEmail" ErrorMessage="Please Enter Email" style="color: red; visibility: visible; font-size:small"/>--%>
                <br />
                  <%--<asp:RegularExpressionValidator runat="server" ID="revWebsite" ControlToValidate="txtEmail"     ErrorMessage="Valid Email is required." ValidationExpression="^(([\w\.\-_]+)@([\w-]+)\.([a-z]{2,8})([a-z]{2,8})?)$" style="color: red; visibility: visible; font-size:small; padding-left:10px"/>--%>
                                </div>
                            </div>
                        </div>
 
                        <div class="row">
                           
                            <div class="col-5">
                                <asp:Button ID="btnAdd" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="btnAdd_Click"  />
                            </div>
                        </div>
 
 
                    </div>
                </div>
 
               
            </div>
           
            
 
            <div class="col-md-11" style="padding-left:135px; padding-bottom:20px">
                
                <div class="card">
                    <div class="card-body">
 
 
 
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Customer List</h4>
                                    </center>
                            </div>
                        </div>
 
                       
 
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="dgvCustomerdetail" runat="server" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="True"  AutoGenerateEditButton="True" PageSize="5" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                &nbsp;&nbsp;
                                                <asp:Image ID="Image1" runat="server" Height="85px" Width="111px" ImageUrl='<%# Bind("ImageURL") %>' />
                                                &nbsp;&nbsp; Customer ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtCustomerID" runat="server" Text='<%# Bind("ID") %>' Enabled='False'></asp:TextBox>
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Customer Name:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtCustomername" runat="server" Text='<%# Bind("CustomerName") %>' Enabled='<%# Bind("Enabled") %>'></asp:TextBox>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phone No:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:TextBox ID="txtPhoneno" runat="server" Text='<%# Bind("PhoneNo") %>' Enabled='<%# Bind("Enabled") %>' ></asp:TextBox>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("EmailAddress") %>' Enabled='<%# Bind("Enabled") %>' ></asp:TextBox>
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' Enabled='<%# Bind("Enabled") %>' ></asp:TextBox>
                                                <br />
                                                <br />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                               
                            </div>
                        </div>
 
 
                    </div>
                </div>
                    
 
 
            </div>
 
        </div>
        
         <a href="Dashboard"><< Back to Homea>
</asp:Content>

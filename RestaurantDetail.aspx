<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RestaurantDetail.aspx.cs" Inherits="GoodFoodCompany.WebForm3" %>
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
                                        <h4>Restaurant Details</h4>
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
                                <label>Restaurant Name</label>
                                <div class="form-group">

                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtrestaurantname" runat="server" placeholder="Restaurant Name"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ID="RFVRestaurantName" ControlToValidate="txtrestaurantname" ErrorMessage="Please Enter the Restuarant Name" style="color: red; visibility: visible; font-size:small"/>--%>
            
                               
                                        
                                    </div>

                                </div>
                            </div>
 
                            <div class="col-md-10">
                                <label>Address</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="txtaddress" runat="server" placeholder="Address"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator runat="server" ID="RFVAddress" ControlToValidate="txtaddress" ErrorMessage="Please Enter the Address" style="color: red; visibility: visible; font-size:small"/>--%>
                                    </div>
                                </div>
                            </div>
                              <div class="col-md-6">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtcontactno" runat="server" placeholder="Contact No"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ID="RFVContactNo" ControlToValidate="txtcontactno" ErrorMessage="Please Enter the Contact No" style="color: red; visibility: visible; font-size:small"/>--%>
                    
                                </div>
                            </div>
                             
                            <div class="col-md-6">
                                <label>Website</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtwebsite" runat="server" placeholder="Website"></asp:TextBox>
            
                  <asp:RegularExpressionValidator runat="server" ID="revWebsite" ControlToValidate="txtwebsite"     ErrorMessage="Valid Website is required." ValidationExpression="^(([\w]+)\.([a-z]{2,8}))$" style="color: red; visibility: visible; font-size:small"/>
                                </div>
                            </div>
                        </div>
 
                        <div class="row">
                           
                            <div class="col-5">
                                <asp:Button ID="btnAdd" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            </div>
                        </div>
 
 
                    </div>
                </div>
 
               
            </div>
           
            
 
            <div class="col-md-13" style="padding-left:145px; padding-bottom:20px">
                
                <div class="card">
                    <div class="card-body">
 
 
 
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Restaurant List</h4>
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
                                <asp:GridView class="table table-striped table-bordered" ID="dgvrestaurantdetail" runat="server" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="True"  AutoGenerateEditButton="True" PageSize="5" DataKeyNames="ID">
                                </asp:GridView>
                               
                            </div>
                        </div>
 
 
                    </div>
                </div>
                    
 
 
            </div>
 
        </div>
        
         <a href="Dashboard"><< Back to Home</a>
                
    </div>
</asp:Content>

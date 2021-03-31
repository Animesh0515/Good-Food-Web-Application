<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeliveryAddressDetail.aspx.cs" Inherits="GoodFoodCompany.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
     <div class="container">
        <div class="row" >
            <div class="col-md-9" style="padding-left:390px; padding-bottom:20px">
 
                <div class="card">
                    <div class="card-body">
 
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Delivery Address Details</h4>
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
                                <label>Address Name</label>
                                <div class="form-group">

                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtaddressname" runat="server" placeholder="Address Name"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ID="RFVAddressName" ControlToValidate="txtaddressname" ErrorMessage="Please Enter the Address Name" style="color: red; visibility: visible; font-size:small"/>--%>
            
                               
                                        
                                    </div>

                                </div>
                            </div>
 
                            <div class="col-md-10">
                                <label>Latitude</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="txtlatitude" runat="server" placeholder="Latitude"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator runat="server" ID="RFVLatitude" ControlToValidate="txtlatitude" ErrorMessage="Please Enter the Latitude" style="color: red; visibility: visible; font-size:small"/>--%>
                                    </div>
                                </div>
                            </div>
                              <div class="col-md-6">
                                <label>Longitude</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtlongitude" runat="server" placeholder="Longitude"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ID="RFVLongitude" ControlToValidate="txtlongitude" ErrorMessage="Please Enter the Longitude" style="color: red; visibility: visible; font-size:small"/>--%>
                    
                                </div>
                            </div>
                             
                            <div class="col-md-6">
                                <label>Zip Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtzipcode" runat="server" placeholder="Zip Code"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ID="RFVZipCode" ControlToValidate="txtzipcode" ErrorMessage="Please Enter the Zip Code" style="color: red; visibility: visible; font-size:small"/>--%>
            
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
           
            
 
            <div class="col-md-12" style="padding-left:130px; padding-bottom:20px">
                
                <div class="card">
                    <div class="card-body">
 
 
 
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Delivery Address List</h4>
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
                                <asp:GridView class="table table-striped table-bordered" ID="dgvdeliveryaddress" runat="server" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="True"  AutoGenerateEditButton="True" PageSize="5" DataKeyNames="ID">
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


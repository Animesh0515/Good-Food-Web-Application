<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DishDetail.aspx.cs" Inherits="GoodFoodCompany.WebForm2" %>
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
                                        <h4>Dish Details</h4>
                                    </center>
                            </div>
                        </div>
 
                        
 
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col-md-9">
                                <label>Dish Code</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtdishcode" runat="server" placeholder="DishCode"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RFVDishCode" ControlToValidate="txtdishcode" ErrorMessage="Please Enter the Dish Code" style="color: red; visibility: visible; font-size:small"/>
                                                                                
                                    </div>
                                </div>
                            </div>
 
                            <div class="col-md-9">
                                <label>Dish Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="txtdishname" runat="server" placeholder="Dish Name"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RFVDishName" ControlToValidate="txtdishname" ErrorMessage="Please Enter the Dish Name" style="color: red; visibility: visible; font-size:small"/>
                                </div>
                                </div>
                            </div>
                              <div class="col-md-12">
                                <label>Local or Another Name</label>
                                <div class="form-group">
                                    <div class="input-group">

                                    <asp:TextBox CssClass="form-control" ID="txtlocalname" runat="server" placeholder="Local name or another name"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RFVlocalName" ControlToValidate="txtlocalname" ErrorMessage="Please Enter the Local Name" style="color: red; visibility: visible; font-size:small"/>
                                </div>
                                </div>
                            </div>
                             
                            
                        
                       <%-- <div class="col-md-4">
                            <label>Loyalty Point</label>
                            <div class="form-group">
                                    <div class="input-group">
                        <asp:DropDownList ID="ddlBooks" runat="server">
                    <asp:ListItem Value="--Select Loyalty Point--"></asp:ListItem>
            

                </asp:DropDownList>
                                </div>
                                </div>
                            </div>--%>
                      
                           </div>

                        <div class="row">
                           
                            <div class="col-5">
                                <asp:Button ID="btnAdd" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="btnAdd_Click1" />
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
                                        <h4>Dish List</h4>
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
                                <asp:GridView class="table table-striped table-bordered" ID="dgvDishDetail" runat="server" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="True"  AutoGenerateEditButton="True" PageSize="5" DataKeyNames="ID">
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

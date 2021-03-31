<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoyaltyPointDetail.aspx.cs" Inherits="GoodFoodCompany.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row" >
            <div class="col-md-8" style="padding-left:390px; padding-bottom:20px">
 
                <div class="card">
                    <div class="card-body">
 
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Loyalty Point Details</h4>
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
                                <label>loyalty Point</label>
                                <div class="form-group">

                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtloyaltypoint" runat="server" placeholder="Loyalty Point"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ID="RFVLoyaltyPoint" ControlToValidate="txtloyaltypoint" ErrorMessage="Please Enter the Loyalty Point" style="color: red; visibility: visible; font-size:small"/>--%>
            
                               
                                        
                                    </div>

                                </div>
                            </div>
 
                            <div class="col-md-12">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="txtStartDate" runat="server" placeholder="MM/DD/YYYY hh:mm"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator runat="server" ID="RFVStartDate" ControlToValidate="txtStartDate" ErrorMessage="Please Enter the Start Date" style="color: red; visibility: visible; font-size:small"/>--%>
                                            <%--<asp:RegularExpressionValidator runat="server" ID="revStartDate" ControlToValidate="txtStartDate"     ErrorMessage="Valid Start Date is required." ValidationExpression="^(([0-9]{2})[-]([a-zA-z]{3})[-]([0-9]{4})/s([0-9]{2}):([0-9]{2}))$" style="color: red; visibility: visible; font-size:small; padding-left:10px"/>--%>

                                    </div>
                                </div>
                            </div>
                              <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtEndDate" runat="server" placeholder="MM/DD/YYYY hh:mm"></asp:TextBox>
            <%--<asp:RequiredFieldValidator runat="server" ID="RFVEndDate" ControlToValidate="txtEndDate" ErrorMessage="Please Enter the End Date" style="color: red; visibility: visible; font-size:small"/>--%>
                    
                                </div>
                            </div>
                             
                           
                        </div>
 
                        <div class="row">
                           
                            <div class="col-5">
                                <asp:Button ID="btnAdd" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="btnAdd_Click1"  />
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
                                        <h4>Loyalty Point List</h4>
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
                                 <asp:GridView class="table table-striped table-bordered" ID="dgvloyaltypointdetail" runat="server" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="True"  AutoGenerateEditButton="True" PageSize="5" DataKeyNames="Code">
                                </asp:GridView>
                               
                            </div>
                        </div>
 
 
                    </div>
                </div>
                    
 
 </div>
            </div>
 
        </div>
        
         <a href="Dashboard"><< Back to Home</a>
</asp:Content>

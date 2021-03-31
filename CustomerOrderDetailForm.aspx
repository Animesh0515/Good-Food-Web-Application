<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerOrderDetailForm.aspx.cs" Inherits="GoodFoodCompany.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        position: relative;
        display: -ms-flexbox;
        display: flex;
        -ms-flex-wrap: wrap;
        flex-wrap: wrap;
        -ms-flex-align: stretch;
        align-items: stretch;
        width: 75%;
        left: -36px;
        top: 6px;
    }
    .auto-style2 {
        display: block;
        font-size: 1rem;
        font-weight: 400;
        line-height: 1.5;
        color: #495057;
        background-clip: padding-box;
        border-radius: .25rem;
        transition: none;
        border: 1px solid #ced4da;
        background-color: #fff;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>   
        
        <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CUSTOMER ORDER DETAIL FORM</h1>
            
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-15" style="padding-left: 750px">

                <div class="form-group">

                    <div class="auto-style1">
                        <asp:TextBox CssClass="auto-style2" ID="txtcustomername" runat="server" placeholder="Search" Width="513px"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFVCustomerName" ControlToValidate="txtcustomername" ErrorMessage="Please Enter the Customer Name" style="color: red; visibility: visible; font-size:small"/>
                    </div>


                </div>
                <div class="row">

                    <div class="col-7.5" style="padding-left: 130px;">
                        <asp:Button ID="btnAdd" class="btn btn-lg btn-block btn-danger" runat="server" Text="Search" Style="padding-left: 20px; text-align: center; font-size: 1.15rem; line-height: 1;" OnClick="btnAdd_Click" Width="234px" />
                    </div>
                </div>
               
            </div>
        </div>
        <div class="row" style="padding-top:20px; padding-bottom:400px;">
            <div class="col">
                <asp:GridView class="table table-striped table-bordered" ID="dgvcustomerorderdetail" runat="server"  EmptyDataText="No records has been added."  PageSize="5" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Cutsomer Order Details">
                            <ItemTemplate>
                                        Order No:
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OrderNumber") %>'></asp:Label>
                                <br />
                                Dish Code:
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DishCode") %>'></asp:Label>
                                <br />
                                Dish Name:
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DishName") %>'></asp:Label>
                                <br />
                                Local or Another Name:
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("LocalName") %>'></asp:Label>
                                <br />
                                Order Unit:
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("OrderUnit") %>'></asp:Label>
                                <br />
                                Line Total:
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("LineTotal") %>'></asp:Label>
                                <br />
                                Total Amount:
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:Label>
                                <br />
                                Loyalty Point :
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("LoyaltyPoint") %>'></asp:Label>
                                <br />
                                Delivery Address:&nbsp;
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("DeliveryAddress") %>'></asp:Label>
                                        &nbsp;
                                    </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;ORDERNUMBER&quot;, &quot;LOYALTYPOINT_CODE&quot;, &quot;DISH_ID&quot;, &quot;ORDERUNIT&quot;, &quot;LINETOTAL&quot; FROM &quot;ORDERDETAIL&quot;"></asp:SqlDataSource>
            </div>
        </div>
    </div>

</asp:Content>

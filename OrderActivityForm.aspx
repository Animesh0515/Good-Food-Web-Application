<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrderActivityForm.aspx.cs" Inherits="GoodFoodCompany.WebForm9" %>
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
        .auto-style3 {
            position: relative;
            width: 34%;
            -ms-flex: 0 0 50%;
            flex: 0 0 50%;
            max-width: 50%;
            left: 145px;
            top: -21px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style4 {
            margin-left: 880px;
        }
        .auto-style5 {
            margin-right: 0px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>   
        
        <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ORDER ACTIVITY FORM</h1>
            
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-15" style="padding-left: 750px">

                <div class="form-group">

                    <div class="auto-style1">
                        <asp:TextBox CssClass="auto-style2" ID="txtcustomername" runat="server" placeholder="Search" Width="513px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator runat="server" ID="RFVDishName" ControlToValidate="txtdishname" ErrorMessage="Please Enter the Dish Name" style="color: red; visibility: visible; font-size:small"/>--%>
                    </div>


                </div>
                <br />
                <div class="auto-style3">
                Month <asp:Label ID="lblmonthwarn" runat="server" Text="*Please Select the month" Font-Size="Smaller" ForeColor="Red"></asp:Label>
&nbsp;<div class="form-group">
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlmonths" runat="server" DataTextField="Month" DataValueField="ORDERMONTH" DataSourceID="SqlDataSource1">
                    <asp:ListItem Value="--Select Month--"></asp:ListItem>
            

                </asp:DropDownList>
                                </div>
                                </div>
                            </div>
                <div class="row">

                    <div class="col-7.5" style="padding-left: 130px;">
                        <asp:Button ID="btnAdd" class="btn btn-lg btn-block btn-danger" runat="server" Text="Search" Style="padding-left: 20px; text-align: center; font-size: 1.15rem; line-height: 1;"  Width="234px" OnClick="btnAdd_Click"   />
                    </div>
                </div>
               
            </div>
        </div>
        <div class="row" style="padding-top:20px; padding-bottom:400px;">
            <div class="col">
                <asp:GridView class="table table-striped table-bordered" ID="dgvorderactivity" runat="server"  EmptyDataText="No records has been added."  PageSize="5" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style5" ForeColor="#333333" GridLines="None" Width="1000px" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Cutsomer Order Details">
                            <ItemTemplate>
                                        Restaurant ID:
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                <br />
                                        Restaurant Name:
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("RestaurantName") %>'></asp:Label>
                                <br />
                                        Address:
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                <br />
                                        Order Number:
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("OrderNumber") %>'></asp:Label>
                                <br />
                                        Order Date:
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("OrderDate") %>'></asp:Label>
                                <br />
                                        Dish Name:
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("DishName") %>'></asp:Label>
                                <br />
                                        Order Unit:
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("OrderUnit") %>'></asp:Label>
                                        <br />
                                        LineTotal:<asp:Label ID="Label8" runat="server" Text='<%# Bind("LineTotal") %>'></asp:Label>
                                        <br />
                                        Delivered:<asp:Label ID="Label9" runat="server" Text='<%# Bind("DeliveryStatus") %>'></asp:Label>
                                <br />
                                <br />
                                    </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT Distinct TO_CHAR(order_datetime, 'MM') ORDERMONTH, TO_CHAR(order_datetime, 'mon') Month FROM &quot;ORDERS&quot;"></asp:SqlDataSource>
            </div>
            <p class="auto-style4">
                &nbsp;</p>
            <p class="auto-style4">
                <asp:Label ID="lblmonthbilltext" runat="server" ForeColor="#3333FF" Text="Label"></asp:Label>
                <asp:Label ID="lblmonthamount" runat="server" ForeColor="#3333FF" Text="Label"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>

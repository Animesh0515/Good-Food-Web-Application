<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DishSearchForm.aspx.cs" Inherits="GoodFoodCompany.WebForm8" %>
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

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>   
        
        <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DISH SEARCH FORM</h1>
            
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-15" style="padding-left: 750px">

                <div class="form-group">

                    <div class="auto-style1">
                        <asp:TextBox CssClass="auto-style2" ID="txtdishname" runat="server" placeholder="Search" Width="513px"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RFVDishName" ControlToValidate="txtdishname" ErrorMessage="Please Enter the Dish Name" style="color: red; visibility: visible; font-size:small"/>
                    </div>


                </div>
                <div class="row">

                    <div class="col-7.5" style="padding-left: 130px;">
                        <asp:Button ID="btnAdd" class="btn btn-lg btn-block btn-danger" runat="server" Text="Search" Style="padding-left: 20px; text-align: center; font-size: 1.15rem; line-height: 1;"  Width="234px" OnClick="btnAdd_Click" />
                    </div>
                </div>
               
            </div>
        </div>
        <div class="row" style="padding-top:20px; padding-bottom:400px;">
            <div class="col">
                <asp:GridView class="table table-striped table-bordered" ID="dgvrestaurantdish" runat="server"  EmptyDataText="No records has been added."  PageSize="5" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Dish Details">
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
                                        Contact No:
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                <br />
                                        Website:
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Website") %>'></asp:Label>
                                <br />
                                        Dish Rate:
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("DishRate") %>'></asp:Label>
                                <br />
                                        Loyalty Point:
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("LoyaltyPoint") %>'></asp:Label>
                                <br />
                                <br />
                                    </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;ORDERNUMBER&quot;, &quot;LOYALTYPOINT_CODE&quot;, &quot;DISH_ID&quot;, &quot;ORDERUNIT&quot;, &quot;LINETOTAL&quot; FROM &quot;ORDERDETAIL&quot;"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>

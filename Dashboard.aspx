<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="GoodFoodCompany.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img-fluid {
    width: 100%!important;
    height: 400px!important;
}
        .w-100 {
    /*width: 100% !important;*/
    height: 200px !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <section>
        
        <img src="Image/good%20food.jpg" class="img-fluid" />
    </section>
    <section>
        <div class="container">
        <div class="row">
            <div class="col-12">
               <center>
                  <h2>Our Features</h2>
                   <h3>CRUD Operation</h3>
                  <p><b>Our 4 Primary Features  </b></p>
               </center>
            </div>
         </div>
             <div class="row">
            <div class="col-md-4" style="padding-top:5px">
               <center>
                  <img width="150px" src="Image/add.png" style="height:150px"/>
                  <h4>Add</h4>
                  <p class="text-justify">This application allow user to add  details to multiple tables. </p>
               </center>
            </div>
                  <div class="col-md-4">
               <center>
                  <img width="150px" src="Image/update.jpg"/>
                  <h4>Update</h4>
                  <p class="text-justify">Here, the information or details can be update with only few clicks.</p>
               </center>
            </div>
                <div class="col-md-4">
               <center>
                  <img width="150px" src="Image/delete.png"/>
                  <h4>Delete</h4>
                  <p class="text-justify">Application gives the flexibility to delete the information or details with one click.</p>
               </center>
            </div>
        </div>
            <div class="row">
            <div class="col-md-8" style="padding-left:380px">
               <center>
                  <img width="150px" src="Image/search.jpg" style="height:150px"/>
                  <h4>Search</h4>
                  <p class="text-justify">This application also have the feature to search order details of customer, dish details, and the customer history. </p>
               </center>
            </div>
         </div>
            </div>
    </section>
        
   
        
</asp:Content>

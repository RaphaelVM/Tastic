﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="Tastic.products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Producten</title>
        <!-- Bootstrap css -->
        <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
        <link rel="stylesheet" type="text/css" href="css/bootstrap-grid.css" />
        <link rel="stylesheet" type="text/css" href="css/bootstrap-reboot.css" />

        <!-- Custom css -->
        <link href="styles/global.css" rel="stylesheet" />

        <!-- Custom js -->
        <script src="js/scripts.js"></script>

        <!-- jQuery js -->
        <script src="js/jquery-3.4.1.min.js"></script>

        <!-- Bootstrap js -->
        <script src="js/bootstrap.js"></script>
        <script src="js/bootstrap.bundle.js"></script>
        
        <!-- Fontawesome js -->
        <script src="https://kit.fontawesome.com/244b76c52f.js" crossorigin="anonymous"></script>
    </head>
    <body>  
        <div id="mySidenav" class="sidenav text-left">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
            <a href="#">About</a>
            <a href="#">Services</a>
            <a href="#">Clients</a>
            <a href="#">Contact</a>
        </div>

        <nav class="navbar navbar-inverse navbar-cust">
            <div class="container-fluid">
                <div class="navbar-header">
                    <span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776;</span>
                </div>
                <ul class="nav navbar-nav navbar-center">
                    <li><img src="images/finalLogoBlack.png" width="120px" alt="tasticLogo" class="text-center" /></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <i class="fas fa-shopping-cart shopping-cart"></i>
                </ul>
            </div>
        </nav>

        <form id="form1" runat="server">
            <div class="backgroundProducts">
                <div class="row">
                    <div class="col-md-12 flexThingy">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

                        <asp:Panel ID="panContainer" runat="server" BorderColor="#8FDD3C" BorderStyle="Solid" BorderWidth="1px">
                            fafa

                            fafa

                            <br />

                            faf

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>

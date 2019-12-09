<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="Tastic.products" %>

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
        <div id="mySidenav" class="sidenav text-left sidenav-cust">
            <a href="javascript:void(0)" class="closebtn " onclick="closeNav()"><i class="fas fa-times"></i></a>
            <a href="#" id="walletAmount" runat="server">"Wallet Waarde"</a>
            <div class="spacer"></div>
            <a href="#">Producten</a>
            <div class="spacer"></div>
            <a href="#">Instellingen</a>
            <div class="spacer"></div>
            <a href="#">Afmelden</a>
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
                    <div class="col-md-12">
                        <div class="d-flex justify-content-center align-items-center categories-list">
                            <asp:Button ID="btnAlles" runat="server" Text="Alle producten" CssClass="btn-to-lbl categories" OnClick="btnAlles_Click" style="height: 29px" />
                            <asp:Button ID="btnBroodjes" runat="server" Text="Broodjes" CssClass="btn-to-lbl categories" OnClick="btnbroodjes_Click" />
                            <asp:Button ID="btnSoepen" runat="server" Text="Soepen" CssClass="btn-to-lbl categories" OnClick="btnSoepen_Click" />
                            <asp:Button ID="btnSnacks" runat="server" Text="Snacks" CssClass="btn-to-lbl categories" OnClick="btnSnacks_Click" />
                            <asp:Button ID="btnDranken" runat="server" Text="Dranken" CssClass="btn-to-lbl categories" OnClick="btnDranken_Click" />
                        </div>

                        <asp:Panel ID="productsContainer" runat="server" BorderColor="#8FDD3C" BorderStyle="Solid" BorderWidth="1px" BackColor="#f9fff4">
                            
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>

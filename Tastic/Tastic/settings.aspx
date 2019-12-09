<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="Tastic.settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Instellingen</title>
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
        <a href="#">"Wallet Waarde"</a>
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
        <div class="container">
            <div class="row">
                <div class="col-md-12 flexThingy">
                    <div class="formContainer mg-top-calc-10">
                        <form>
                            <div class="formHeader">
                                <h1>Instellingen</h1>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control formStyle" placeholder="Email van huidige user"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtPassword" runat="server" type="password" class="form-control formStyle" placeholder="Wachtwoord van huidige user"></asp:TextBox>
                            </div>
                            <select class="form-group form-control formStyle">
                                <option ID="cbDutch" value="NL">Nederlands</option>
                                <option ID="cbEnglish" value="EN">English</option>
                            </select>
                            <asp:Button runat="server" Text="Opslaan" CssClass="btn btn-primary buttonStyle float-none" ID="btnSave" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

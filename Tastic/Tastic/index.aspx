<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tastic.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Aanmelden</title>
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
        <form id="form1" runat="server">
            <div class="backgroundMain">
                <div class="row">
                    <div class="col-md-12 flexThingy">
                        <div class="formContainer">
                            <div class="logoLogin">
                                <img src="images/finalLogoTastic.png" />
                            </div>
                            <form>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control formStyle" placeholder="E-mail"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" type="password" class="form-control formStyle" placeholder="Wachtwoord"></asp:TextBox>
                                </div>
                                <asp:Button runat="server" Text="Aanmelden" CssClass="btn btn-primary buttonStyle float-left" ID="btnLogin" OnClick="btnLogin_Click" />
                                <asp:Button ID="btnRegistreren" runat="server" Text="Registreren" CssClass="btn btn-primary buttonStyle float-right" OnClick="btnRegistreren_Click" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>

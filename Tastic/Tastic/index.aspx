<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tastic.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Login</title>
        <!-- Bootstrap css -->
        <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
        <link rel="stylesheet" type="text/css" href="css/bootstrap-grid.css" />
        <link rel="stylesheet" type="text/css" href="css/bootstrap-reboot.css" />
        <!-- Custom css -->
        <link href="styles/global.css" rel="stylesheet" />

        <!-- Bootstrap js -->
        <script src="js/bootstrap.js"></script>
        <script src="js/bootstrap.bundle.js"></script>
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
                                    <input type="email" class="form-control formStyle" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="E-mail..." />
                                </div>
                                <div class="form-group">
                                    <input type="password" class="form-control formStyle" id="exampleInputPassword1" placeholder="Wachtwoord..." />
                                </div>
                                <asp:Button runat="server" Text="Login" CssClass="btn btn-primary buttonStyle float-left" />
                                <asp:Button runat="server" Text="Register" CssClass="btn btn-primary buttonStyle float-right" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>

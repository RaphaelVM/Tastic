<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Tastic.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Registreren</title>
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
                                <div runat="server" class="form-group invisible-cust" id="createERRPar">
                                    <asp:Label ID="lblCreateERR" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="form-group">
                                     <asp:TextBox ID="txtVoornaam" class="form-control formStyle" placeholder="Voornaam" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                     <asp:TextBox ID="txtAchternaam" class="form-control formStyle" placeholder="Achternaam" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                     <asp:TextBox ID="txtEmail" class="form-control formStyle" placeholder="Email" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtWachtwoord" class="form-control formStyle" placeholder="Wachtwoord" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group invisible-cust" id="passERR">
                                    <asp:Label ID="lblPass" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtWachtwoordHerh" class="form-control formStyle" placeholder="Herhaal wachtwoord" runat="server" TextMode="Password" OnKeyUp="javascript:checkPass(this);"></asp:TextBox>
                                </div>
                                <asp:Button runat="server" ID="btnRegister" Text="Registreren" CssClass="btn btn-primary buttonStyle float-left" OnClick="btnRegister_Click" />
                                <asp:Button runat="server" ID="btnCancel" Text="Annuleren" CssClass="btn btn-primary buttonStyle float-right" OnClick="btnCancel_Click" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>

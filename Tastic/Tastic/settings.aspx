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

        <!-- Bootstrap js -->
        <script src="js/bootstrap.js"></script>
        <script src="js/bootstrap.bundle.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
                <div class="row">
                    <div class="col-md-12 flexThingy">
                        <div class="formContainer">
                            <form>
                                <div class="formHeader">
                                    <h1>Instellingen</h1>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control formStyle" placeholder="E-mail"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" type="password" class="form-control formStyle" placeholder="Wachtwoord"></asp:TextBox>
                                </div>
                                <select class="form-group">
                                    <option ID="cbDutch" value="NL">Nederlands</option>
                                    <option ID="cbEnglish" value="EN">English</option>
                                </select>
                                <asp:Button runat="server" Text="Opslaan" CssClass="btn btn-primary buttonStyle float-left" ID="btnSave" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>

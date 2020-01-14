<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edituser.aspx.cs" Inherits="Tastic.edituser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Edit user - Admin</title>
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
        <form id="editUserForm" runat="server">
            <div id="mySidenav" class="sidenav text-left sidenav-cust">
                <a href="javascript:void(0)" class="closebtn " onclick="closeNav()"><i class="fas fa-times"></i></a>
                <asp:LinkButton ID="walletAmount" runat="server"></asp:LinkButton>
                <div class="spacer"></div>
                <asp:LinkButton ID="linkProducts" runat="server" OnClick="linkProducts_Click">Producten</asp:LinkButton>
                <div class="spacer"></div>
                <asp:LinkButton ID="linkSettings" runat="server" OnClick="linkSettings_Click">Instellingen</asp:LinkButton>
                <asp:PlaceHolder ID="extraOptions" runat="server"></asp:PlaceHolder>
                <div class="spacer"></div>
                <asp:LinkButton ID="linkLogout" runat="server" OnClick="linkLogout_Click">Afmelden</asp:LinkButton>
            </div>

            <nav class="navbar navbar-inverse navbar-cust">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776;</span>
                    </div>
                    <ul class="nav navbar-nav navbar-center">
                        <li><img src="images/finalLogoBlack.png" width="120px" alt="tasticLogo" class="text-center" /></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right d-flex flex-row-reverse bd-highlight">
                        <i class="fas fa-shopping-cart shopping-cart" onclick="location.href = 'cart.aspx'"></i>
                        <span id="itemsAmount" class="cart-amount rounded-circle" runat="server"></span>
                    </ul>
                </div>
            </nav>

            <div class="backgroundEdituser">
                <div class="row">
                    <div class="col-md-2"></div>

                    <div class="col-md-8">
                        <div runat="server" class="form-group invisible-cust" id="updateUserERRPar">
                            <asp:Label ID="lblUpdateUserERR" runat="server" Text=""></asp:Label>
                        </div>
                        <table style="width: 100%; margin-top: 10%;">
                            <tr>
                                <td class="editUser-table-data">
                                    Voornaam: 
                                </td>

                                <td>
                                    <asp:TextBox ID="txtFirstname" runat="server" class="form-control formStyle"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="editUser-table-data">
                                    Achternaam: 
                                </td>

                                <td>
                                    <asp:TextBox ID="txtLastname" runat="server" class="form-control formStyle"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="editUser-table-data">
                                    Geslacht: 
                                </td>

                                <td>
                                    <asp:DropDownList ID="ddlGeslacht" runat="server" class="form-control formStyle">
                                        <asp:ListItem Value="Man">Man</asp:ListItem>
                                        <asp:ListItem Value="Woman">Vrouw</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td class="editUser-table-data">
                                    Wallet aantal: 
                                </td>

                                <td>
                                    <asp:TextBox ID="txtWalletAmount" runat="server" class="form-control formStyle"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="editUser-table-data">
                                    Bedrijf: 
                                </td>

                                <td>
                                    <asp:DropDownList ID="ddlCompanies" runat="server" class="form-control formStyle">

                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td class="editUser-table-data">
                                    Rol: 
                                </td>

                                <td>
                                    <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control formStyle">

                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td style="text-align: left;">
                                    <asp:Button runat="server" Text="Annuleren" CssClass="btn btn-primary buttonStyle float-left" ID="btnCancel" OnClick="btnCancel_Click" />
                                </td>

                                <td style="text-align: right;">
                                    <asp:PlaceHolder ID="saveButtonPlaceholder" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div class="col-md-2"></div>
                </div>
            </div>
        </form>
    </body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="Tastic.payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Payment</title>
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

        <div class="backgroundPayment">
            <div class="row">
                <div class="col-md-12">
                    <asp:Panel ID="productContainer" runat="server" CssClass="cartContainer">
                            
                    </asp:Panel>

                    <div class="totalAmount">
                        <table class="payment-table">
                            <tr>
                                <td colspan="2"><asp:Label ID="subtotalAmount" runat="server" CssClass="paymentTotal"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:Label runat="server" ID="useWalletLabel">Wallet gebruiken </asp:Label></td>
                                <td><asp:PlaceHolder runat="server" ID="checkboxPlaceholder"></asp:PlaceHolder></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:Label ID="totalAmount" runat="server" CssClass="paymentTotal"></asp:Label></td>
                            </tr>
                        </table>
                    </div>

                    <div class="paymentMethod-container">
                        <div class="paymentMethod-options">
                            <asp:DropDownList ID="paymentMethod" runat="server" CssClass="paymentMethodDropdown" onchange="removeFirstItem()" ></asp:DropDownList>
                        </div>
                        <div class="paymentMethod-options">
                            <input type="button" onclick="payOrder()" class="btn btn-primary buttonStyle" id="btnPay" value="Afrekenen" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tastic.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap-grid.css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap-reboot.css" />

    <script src="js/bootstrap.js"></script>
    <script src="js/bootstrap.bundle.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button type="button" runat="server" onserverclick="testBtn_Click" onclick="return false;">Butt</button>
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:Label ID="lblConn" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>

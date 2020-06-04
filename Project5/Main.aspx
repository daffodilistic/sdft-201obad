<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Project5.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGetAccount" runat="server" Text="Get Account" OnClick="btnGetAccount_Click" />
            <br />
            <asp:Button ID="btnGetCustomer" runat="server" Text="Get Customer" OnClick="btnGetCustomer_Click"/>
            <br />
            <asp:Label ID="lblValue" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnTransferMoney" runat="server" Text="Transfer Money" OnClick="btnTransferMoney_Click"/>
            <br />
        </div>
    </form>
</body>
</html>

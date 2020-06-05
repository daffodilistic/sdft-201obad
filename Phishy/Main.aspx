<%@ Page Language="C#" Async="true" MasterPageFile="~/DefaultPage.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Phishy.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGetAccount" runat="server" Text="Get Account" OnClick="btnGetAccount_Click" />
            <br />
            <asp:Button ID="btnGetCustomer" runat="server" Text="Get Customer" OnClick="btnGetCustomer_Click" />
            <br />
            <asp:Label ID="lblValue" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnTransferMoney" runat="server" Text="Transfer Money" OnClick="btnTransferMoney_Click" />
            <br />
        </div>
    </form>
</asp:Content>

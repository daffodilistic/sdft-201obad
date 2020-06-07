<%@ Page Language="C#" Async="true" MasterPageFile="~/templates/DefaultPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Phishy.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblValue" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnTransferMoney" runat="server" Text="Transfer Money" OnClick="btnTransferMoney_Click" />
            <br />
        </div>
    </form>
</asp:Content>

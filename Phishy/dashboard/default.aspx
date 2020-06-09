<%@ Page Language="C#" Async="true" MasterPageFile="~/templates/DefaultPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Phishy.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark bg-primary">
        <a class="navbar-brand" href="#">
            <div class="row mx-auto">
                <img src="/assets/brand.svg" width="64" height="64" alt="" loading="lazy">
                <div class="brand my-auto">Phishy Bank</div>
            </div>
        </a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavDropdown">
            <div class="mr-auto">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="./"><b>Home</b></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="FundTransfer.aspx">Transfer</a>
                    </li>
                </ul>
            </div>
            <ul class="navbar-nav">
                <li class="nav-link active my-auto mx-2">
                    <i class="fas fa-user-circle"></i>&nbsp;
                    <asp:Label ID="lblUserName" runat="server" Text="John Doe"></asp:Label>
                </li>
                <li class="nav-item">
                    <a class="btn btn-secondary" href="/logout.ashx">
                        <i class="fas fa-sign-out-alt"></i>&nbsp;Logout
                    </a>
                </li>
            </ul>
        </div>
    </nav>
    <div class="container pt-body">
        <h1><b>Hello,
            <asp:Label ID="lblUserFirstName" runat="server" Text="John Doe"></asp:Label>!</b></h1>
        <br>
        <h3>Your Account Summary</h3>
        <hr>
        <h5>Account No. <b>
            <asp:Label ID="lblAccountId" runat="server" Text="62353535"></asp:Label></b></h5>
        <h4>Balance Available: <b>
            <asp:Label ID="lblAccountBalance" runat="server" Text="$18.88"></asp:Label></b></h4>
        <br>
        <h3>Recent Transactions</h3>
        <hr>
        <asp:Label ID="lblValue" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

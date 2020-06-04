<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PhishyBank.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="lblDebugStatus" runat="server" Visible="false" Text="DEBUG MODE"></asp:Label>
        <nav class="navbar sticky-top navbar-expand-lg navbar-dark" style="background-color: #FF3435;">
            <a class="navbar-brand" href="#">
                <div class="row mx-auto">
                    <img src="brand.svg" width="64" height="64" alt="" loading="lazy">
                    <div class="brand my-auto">Phishy Bank</div>
                </div>
            </a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavDropdown">
                <div class="mr-auto">
                </div>
                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <a class="nav-link btn btn-success" href="login.aspx">
                            <i class="fas fa-sign-in-alt"></i>&nbsp;Login
                        </a>
                    </li>
                </ul>

            </div>
        </nav>
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    One of three columns
                </div>
                <div class="col-sm">
                    One of three columns
                </div>
                <div class="col-sm">
                    One of three columns
                </div>
            </div>
        </div>
        <nav class="navbar fixed-bottom navbar-light bg-light">
            <div class="mr-auto">
            </div>
            <h6 class="navbar-text my-0 py-0">Serving Nigerian Princes since 2020
            </h6>
        </nav>
    </form>
</asp:Content>

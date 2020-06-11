<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/templates/DefaultPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Phishy.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- BEGIN Modal -->
    <div class="modal fade" id="aboutModal" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="staticBackdropLabel">About Phishy Bank</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <h5>Created by</h5>
                    <p class="text-monospace">
                        10200376B Seah Shih Wei Gerome
                        <br />
                        S01623826 Soh Thiam Hing
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- END Modal -->
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark" style="background-color: #E95420;">
        <a class="navbar-brand" href="#">
            <div class="row mx-auto">
                <img src="assets/brand.svg" width="64" height="64" alt="" loading="lazy">
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
                <li class="nav-item">
                    <a class="btn btn-success" href="login.aspx">
                        <i class="fas fa-sign-in-alt"></i>&nbsp;Login
                    </a>
                </li>
            </ul>
        </div>
    </nav>
    <div id="" class="carousel slide carousel-fade" data-interval="5000" data-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img class="d-flex align-items-center justify-content-center img-cover vh-100 w-100" src="assets/landing.jpg" style=" object-position: 0 0;">
                <div class="carousel-caption bg-dark shadow rounded carousel-center">
                    <div class="col">
                        <h1>Preferred Bank of Royalty</h1>
                        <p>Serving Nigerian Princes since 2020</p>
                    </div>
                </div>
            </div>
            <div class="carousel-item">
                <img class="d-flex align-items-center justify-content-center img-cover vh-100 w-100" src="assets/landing-2.jpg">
                <div class="carousel-caption bg-dark shadow rounded carousel-center">
                    <div class="col">
                        <h1>Now Accepting Toilet Paper</h1>
                        <p>Contact us for more information</p>
                    </div>
                </div>
            </div>
            <div class="carousel-item">
                <img class="d-flex align-items-center justify-content-center img-cover vh-100 w-100" src="assets/landing-3.jpg">
                <div class="carousel-caption bg-dark shadow rounded carousel-center">
                    <div class="col">
                        <h1>Bitcoin Transfers Coming Soon</h1>
                        <p>Check back often for updates!</p>
                    </div>
                </div>
        </div>
    </div>
    </div>
    <nav class="navbar fixed-bottom navbar-light bg-light">
        <div class="mr-auto">
            <asp:Label ID="lblDebugStatus" runat="server" Visible="false" Text="DEBUG MODE"></asp:Label>
        </div>
        <h6 class="navbar-text my-0 py-0">Disclaimer: This is a site intended for demo purposes only.
        </h6>
    </nav>
</asp:Content>

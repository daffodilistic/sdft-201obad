﻿<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/templates/DefaultPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Phishy.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <nav class="navbar fixed-top navbar-expand-lg navbar-dark" style="background-color: #FF3435;">
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

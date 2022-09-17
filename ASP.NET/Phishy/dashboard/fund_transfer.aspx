<%@ Page Language="C#" Async="true" MasterPageFile="~/templates/DefaultPage.Master" AutoEventWireup="true" CodeBehind="fund_transfer.aspx.cs" Inherits="Phishy.Dashboard.FundTransfer" %>

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
                    <li class="nav-item">
                        <a class="nav-link" href="./">Home</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="fund_transfer.aspx"><b>Transfer</b></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="modal" data-target="#aboutModal" href="">About</a>
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
        <form id="fundTransferForm" runat="server">
            <div id="transferContainer" runat="server" visible="true">
                <h1 class="font-weight-bold">Transfer Money</h1>
                <br>
                <h3>Recipient Details</h3>
                <hr>
                <div class="row row-cols-1">
                    <div class="col-12">
                        <h4>Transfer To</h4>
                    </div>
                    <div class="col-12 col-md-4">
                        <asp:TextBox ID="txtTransferEmail" runat="server" CssClass="w-100 form-control mb-3" placeholder="john@example.com"></asp:TextBox>
                    </div>
                </div>
                <div class="row row-cols-1">
                    <div class="col-12">
                        <h4>Amount</h4>
                    </div>
                    <div class="col-12 col-md-4">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">$</span>
                            </div>
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder="1.88"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row row-cols-1">
                    <div class="col-12">
                        <h4>Subject</h4>
                    </div>
                    <div class="col-12 col-md-4">
                        <asp:TextBox ID="txtSubject" TextMode="MultiLine" runat="server" CssClass="w-100 form-control mb-3"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 col-md-4">
                        <asp:Button ID="btnTransfer" runat="server" Text="Transfer" OnClick="btnTransfer_Click" CssClass="btn btn-block btn-primary" />
                    </div>
                </div>
            </div>
            <p></p>
            <div id="transferResultContainer" runat="server" visible="false">
                <h1 class="font-weight-bold">Transfer Completed!</h1>
                <br>
                <h3>Transfer Request Details</h3>
                <hr>
                <div class="row row-cols-1">
                    <div class="col-12">
                        <h5>Debiting Account</h5>
                    </div>
                    <div class="col-12 col-md-4">
                        <asp:Label ID="lblSender" runat="server" CssClass="font-weight-bold mb-3"></asp:Label>
                    </div>
                </div>
                <div class="row row-cols-1">
                    <div class="col-12">
                        <h5>Reciever</h5>
                    </div>
                    <div class="col-12 col-md-4">
                        <asp:Label ID="lblReciever" runat="server" CssClass="font-weight-bold mb-3"></asp:Label>
                    </div>
                </div>
                <div class="row row-cols-1">
                    <div class="col-12">
                        <h5>Amount</h5>
                    </div>
                    <div class="col-12 col-md-4">
                        <asp:Label ID="lblAmount" runat="server" CssClass="font-weight-bold mb-3"></asp:Label>
                    </div>
                </div>
                <div class="row row-cols-1">
                    <div class="col-12">
                        <h5>Subject</h5>
                    </div>
                    <div class="col-12 col-md-4">
                        <asp:Label ID="lblSubject" runat="server" CssClass="font-weight-bold mb-3"></asp:Label>
                    </div>
                </div>
                <div class="row row-cols-1">
                    <div class="col-12">
                        <h5>Status</h5>
                    </div>
                    <div class="col-12 col-md-4">
                        <asp:Label ID="lblState" runat="server" CssClass="font-weight-bold mb-3"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 col-md-4">
                        <asp:Button ID="btnBack" runat="server" Text="Back to Home" OnClick="btnBack_Click" CssClass="btn btn-block btn-primary" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>

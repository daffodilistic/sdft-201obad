<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="FundTransfer.aspx.cs" Inherits="Project5.FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            width: 50%;
        }
        .auto-style3 {
            width: 50%;
        }
        .auto-style4 {
            width: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table runat="server" id="tblTxnDetail" visible="true" class="auto-style1">
                <tr>
                    <td class="auto-style2">Transfer To</td>
                    <td>
                        <asp:TextBox ID="txtTransferEmail" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Amount</td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Subject</td>
                    <td>
                        <asp:TextBox ID="txtSubject" TextMode="MultiLine" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnTransfer" runat="server" Text="Transfer" Width="100%" OnClick="btnTransfer_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <p></p>
            <table runat="server" id="tblTxnSummary" visible="false" class="auto-style1">
                <tr>
                    <td class="auto-style2">From</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblSender" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">To</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblReciever" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Subject</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblSubject" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Amount</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                    </td>
                </tr>
<tr>
                    <td class="auto-style2">State</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblState" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="Back To Index" Width="100%" OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>

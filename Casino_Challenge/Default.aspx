<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Casino_Challenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #009933;
            font-size: medium;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            color: #000000;
            font-size: medium;
        }
        .auto-style4 {
            color: #CC0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <asp:Image ID="reelImage0" runat="server" Height="150px" BorderStyle="None" Width="150px" />
            <asp:Image ID="reelImage1" runat="server" Height="150px" BorderStyle="None" Width="150px" />
            <asp:Image ID="reelImage2" runat="server" Height="150px" BorderStyle="None" Width="150px" />
            <br />
            <br />
            Your Bet:
            <asp:TextBox ID="betTextbox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="playButton" runat="server" Height="73px" OnClick="playButton_Click" Text="Play" Width="169px" BackColor="#FFCC00" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="fundsLabel" runat="server"></asp:Label>
            <br />
            <br />
            <strong><span class="auto-style1">1 x Cherry&nbsp;&nbsp; = </span><span class="auto-style3">Your Bet x2</span><br class="auto-style1" />
            <span class="auto-style1">2 x Cherries = </span><span class="auto-style3">Your Bet x3</span><br class="auto-style1" />
            <span class="auto-style1">3 x Cherries = </span><span class="auto-style3">Your Bet x4</span><br class="auto-style1" />
            <span class="auto-style1">3 x 7&#39;s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; =&nbsp; </span><span class="auto-style3">Jackpot!</span><span class="auto-style1"> </span><span class="auto-style3">Your Bet x 100.</span></strong><br />
            <br />
            However... if there are <strong>ANY BAR</strong>&#39;s - <span class="auto-style4">You Lose!!!!!!!!</span><br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>

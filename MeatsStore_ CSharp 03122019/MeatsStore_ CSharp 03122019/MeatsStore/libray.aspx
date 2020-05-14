<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Libray.aspx.cs" Inherits="MeatsStore__CSharp_03122019.MeatsStore.Libray" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link rel="stylesheet" href="MeatsStoreMainStyle.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <header>
                <img src="../Resources/MeatsStore/logo.png"/>
            </header>
                <article class="main">
                <ul class="mainBar">
                    <li class="mainBar"><a href="/MeatsStore/MeatsStoreMain.aspx">Store</a></li>
                    <li class="mainBar" style="background-color: #717171;"><a href="#">Game Library</a></li>
                    <li class="mainBar"><a href="/MeatsStore/AddMoney.aspx">Add Money</a></li>
                    <li class="mainBar"><a href="/Login/LoginMain.aspx">Logout</a></li>
                </ul>
                <p class="infoBar">Welcome back 
                    <asp:Label runat="server" ID="lb_username"/>
                    <asp:Label runat="server" ID="lb_balance" Text="Balance 0.00 DKK"/>
                </p>
                <h1>Your Game Libray</h1>
                <asp:Label runat="server" ID="lb_ownedGames" Text="0 owned games!"/>
            </article>
        </form>
    </body>
</html>

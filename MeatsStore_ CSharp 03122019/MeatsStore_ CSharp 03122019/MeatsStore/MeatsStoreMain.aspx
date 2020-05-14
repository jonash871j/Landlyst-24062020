<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeatsStoreMain.aspx.cs" Inherits="MeatsStore__CSharp_03122019.MeatsStore.MeatsStoreMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link rel="stylesheet" href="MeatsStoreMainStyle.css" />
    </head>
    <body>
        <header>
            <img src="../Resources/MeatsStore/logo.png"/>
        </header>
        <form id="form1" runat="server">
            <article class="main">
                <!--Mainbar-->
                <ul class="mainBar">
                    <li class="mainBar" style="background-color: #717171;"><a href="#">Store</a></li>
                    <li class="mainBar"><a href="/MeatsStore/Libray.aspx">Game Library</a></li>
                    <li class="mainBar"><a href="/MeatsStore/AddMoney.aspx">Add Money</a></li>
                    <li class="mainBar"><a href="/Login/LoginMain.aspx">Logout</a></li>
                </ul>
                <!--Infobar-->
                <p class="infoBar">Welcome back 
                    <asp:Label runat="server" ID="lb_username"/>
                    <asp:Label runat="server" ID="lb_balance" Text="Balance 0.00 DKK"/>
                </p>

                <asp:Label class="shoppingBasket" runat="server" ID="lb_gameBasketCount" />
                <a href="/MeatsStore/GameBasket.aspx">
                    <img class="shoppingBasket" src="../Resources/MeatsStore/shoppingBasket.png" />
                </a>
                <br />
                <!--Title-->
                <h1>Store</h1>

                <!--Shopping table-->
                <asp:Table runat="server" Id="tb_gameTable" CssClass="tb_gameTable"/>
                <br />
            </article>  
        </form>
    </body>
</html>

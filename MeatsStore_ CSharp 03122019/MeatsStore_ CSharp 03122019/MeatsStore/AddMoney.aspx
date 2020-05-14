<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMoney.aspx.cs" Inherits="MeatsStore__CSharp_03122019.MeatsStore.AddMoney" %>

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
                    <li class="mainBar"><a href="/MeatsStore/Libray.aspx"">Game Library</a></li>
                    <li class="mainBar" style="background-color: #717171;"><a href="#">Add Money</a></li>
                    <li class="mainBar"><a href="/Login/LoginMain.aspx">Logout</a></li>
                </ul>
                <p class="infoBar">Welcome back 
                    <asp:Label runat="server" ID="lb_username"/>
                    <asp:Label runat="server" ID="lb_balance"/>
                </p>
                <h1>Add Money $$$</h1>

                <asp:TextBox runat="server" ID="tb_balanceBox" />
                <asp:Button runat="server" ID="bn_addMoney" Text="Add" OnClick="bn_addMoney_Click" />
                <hr />
                <img src="../Resources/MeatsStore/gabenMoney.jpg" width="1536" height="128"/>
            </article>
        </form>
    </body>
</html>

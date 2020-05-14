<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginMain.aspx.cs" Inherits="MeatsStore__CSharp_03122019._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="LoginMainStyle.css">


    <article>
        <h1>Login</h1>

        <!--Login Texboxes-->
        <p> Username:
            <asp:TextBox runat="server" ID="tb_username"/>
        </p>
        <p> Password : 
            <asp:TextBox runat="server" ID="tb_password" TextMode="Password"/>
        </p>

        <!--Error Messages-->
        <asp:Label runat="server" Text="Username or password is invalid!" ForeColor="Red" ID="lb_errAcountInvalid" Visible="false"/>

        <!--Login Buttons-->
        <br />
        <asp:Button runat="server" Text="Signup" ID="bn_signUp" OnClick="bn_signUp_Click" UseSubmitBehavior="false"/>
        <asp:Button runat="server" Text="Login" ID="bn_logIn" OnClick="bn_logIn_Click"/>
     </article>
</asp:Content>

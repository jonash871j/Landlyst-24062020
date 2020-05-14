<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSignup.aspx.cs" Inherits="MeatsStore__CSharp_03122019.Login.LoginSignup" %>

<!DOCTYPE html>
<link rel="stylesheet" href="LoginMainStyle.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

     <article>
        <h1>Signup</h1>

        <!--Signup Texboxes-->
        <p> Username:
            <asp:TextBox runat="server" ID="tb_username"/>
        </p>

        <p> Password :
            <asp:TextBox runat="server" ID="tb_password" TextMode="Password"/>
        </p>
         
        <p> Password :
            <asp:TextBox runat="server" ID="tb_passwordChecker" TextMode="Password"/>
        </p>

         <!--Error Messages-->
        <asp:Label runat="server" Text="Username is invalid!" ForeColor="Red" ID="lb_errUsernameInvalid" Visible="false"/>
        <asp:Label runat="server" Text="Password dosn't match!" ForeColor="Red" ID="lb_errPasswordDontMatch" Visible="false"/>
        <asp:Label runat="server" Text="Password must be at least 8 characters!" ForeColor="Red" ID="lb_errPasswordToShort" Visible="false"/>
        <asp:Label runat="server" Text="Password has to be less than 50 characters!" ForeColor="Red" ID="lb_errPasswordToLong" Visible="false"/>

        <!--Login Buttons-->
        <br />
        <asp:Button runat="server" Text="Back" ID="bn_back" OnClick="bn_back_Click" UseSubmitBehavior="false"/>
        <asp:Button runat="server" Text="Signup" ID="bn_signUp" OnClick="bn_signUp_Click"/>
     </article>

    </form>
</body>
</html>

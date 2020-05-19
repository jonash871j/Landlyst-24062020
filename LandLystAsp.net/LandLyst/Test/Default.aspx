<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LandLyst.Test.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="TestStyle.css" rel="stylesheet" />
    <title>TEST</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label class="InputContainer">test1
                <input type="checkbox" name="name" value="" />
                <span></span>
            </label>
            <label class="InputContainer">test2
                <asp:CheckBox ID="CheckBox1" runat="server" />
                <span></span>
            </label>
        </div>
    </form>
</body>
</html>

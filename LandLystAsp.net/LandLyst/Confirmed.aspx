<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmed.aspx.cs" Inherits="LandLyst.Order.Confirmed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/style.css" rel="stylesheet" />
    <link href="~/SiteIcon.ico" rel="shortcut icon" type="image/x-icon" />
    <webopt:bundlereference runat="server" path="~/Content/css" />

</head>
<body>
    <form id="form1" runat="server">

        <!-- Background Picture -->    
        <div class="BgPic"></div>

        <!-- Top Title and an Anchor to the head page -->
        <a href="..\" style="text-decoration: none">
            <div class="headtitle">
            Hotel Landlyst
        </div>
        </a>

         <!-- The Main Box -->
        <div class="confirmedDiv">   
            <p>
                Dit Reservation er nu blevet Modtaget
                <br />  
                Du kan <a href="Default.aspx">Klik her</a> for at komme tilbage til forsiden
            </p>
        </div>
    </form>
</body>
</html>

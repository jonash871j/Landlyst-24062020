<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmed.aspx.cs" Inherits="LandLyst.Order.Confirmed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/style.css" rel="stylesheet" />
    <webopt:bundlereference runat="server" path="~/Content/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="BgPic"></div>
    <div class="headtitle">
        Hotel Landlyst
    </div>
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

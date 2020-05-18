<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/HeadSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LandLyst._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="NavMenu" class="navBar">
        <div>
            <a href="#">Forside</a>
            <a href="#">Forside</a>
            <i class="fa fa-times" onclick="NavBarFunc('0px', '0', '-150px')"></i>
        </div>
    </div>
    <div class="menuClass">
        <button type="button" id="menuButton" onclick="NavBarFunc('150px', '1', '0px')" class="menuButton btn btn-light">
            <i class="fas fa-bars"></i> Menu
        </button>
    </div>
    <div class="center Header1">
        <h1 class="display-4">Hotel LandLyst</h1>
    </div>
    <div class="bottomBar">
        <div class="Middlebutton">
            <a href="Booking">
                <div>
                    <p>Book<br>Værelse</p>
                </div>
            </a>
        </div>
        <p>sa</p>
        <p>das</p>
        <p>fass</p>
    </div>
    <script>
        function NavBarFunc(height, opacity, top) {
            document.getElementById("NavMenu").style.height = height;            
            document.getElementById("NavMenu").style.opacity = opacity;
            document.getElementById("NavMenu").style.top = top;
        }
    </script>
</asp:Content>

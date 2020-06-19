<%@ Page Title="Landlyst - Kontakt os" Language="C#" MasterPageFile="~/Booking/Booking.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LandLyst.Booking.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Background Picture -->
    <div class="BgPic"></div>

    <!-- Top Menu -->
    <div id="NavMenu" class="navBar">
        <div>
            <a href="..\">Forside</a>
            <a href="..\Booking">Book</a>
            <a href="#">Kontakt os</a>
            <i class="fa fa-times" onclick="NavBarFunc('0px', '0', '-150px')"></i>
        </div>
    </div>

    <!-- Top Title and an Anchor to the head page -->
    <a href="..\" style="text-decoration: none">
        <div class="headtitle">
        Hotel Landlyst
    </div>
    </a>

    <!-- Top Menu button to open the top menu -->
    <div class="menuClass">
        <button type="button" id="menuButton" onclick="NavBarFunc('150px', '1', '0px')" class="menuButton btn btn-light">
            <i class="fas fa-bars"></i> Menu
        </button>
    </div>

    <!-- The Main Box -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg">
                <h5>Kontakt os</h5>


                Vores Hotel ligger på Fyn kysts,
                <br />
                addresse: Vestergade 25700 Svendborg
                <br />
                Email: Contact@LandLyst.dk
                <br />
                Telefon: +45 5612 4259
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>

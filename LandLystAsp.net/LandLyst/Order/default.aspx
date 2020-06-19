<%@ Page Title="Landlyst - Værelse: <nr>" Language="C#" MasterPageFile="~/Order/OrderSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LandLyst.Order.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Background Picture -->
    <div class="BgPic"></div>

    <!-- Top Menu -->
    <div id="NavMenu" class="navBar">
        <div>
            <a href="..\">Forside</a>
            <a href="..\Booking">Book</a>
            <a href="..\Contact">Kontakt os</a>
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
            <div class="col-lg-1"></div>

            <!-- First Colum, Intput data to reserve room -->
            <div class="col-lg">
            <h2>Checkout: Værelse <%Response.Write(Request["Room"]); %></h2>
                <Button type="button" class="RealBtn btn btn-light" onclick="VeiwBox(1, 'NotNewCustomerBox', 'NewCustomerBox')">Ny Kunde</Button>
                <Button type="button" class="RealBtn btn btn-light" onclick="VeiwBox(0, 'NotNewCustomerBox', 'NewCustomerBox')">Tidligere Kunde</Button>
                <br />
                <asp:Label runat="server" CssClass="ErrorText" ID="lb_error" Text=""/>
                <div style="display:none;" id="NotNewCustomerBox">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="tb_emailExist" MaxLength="345" CssClass="form-control inputtext" placeholder="Email"/> 
                    </div>
                    <asp:Button Text="Reservere Værelset" CssClass="RealBtn btn btn-light" ID="bn_reserveExist" runat="server" OnClick="Unnamed1_Click" />
                </div>
                <div id="NewCustomerBox">
                    <div class="form-group" style="display: flex;">
                        <asp:TextBox runat="server" ID="tb_firstName" MaxLength="50" CssClass="form-control inputtext" placeholder="Fornavn"/>  
                        <asp:TextBox runat="server" ID="tb_lastName"  MaxLength="50" CssClass="form-control inputtext" placeholder="Efternavn"/>  
                    </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_phoneNumber"  MaxLength="20" CssClass="form-control inputtext" placeholder="Telefon nummer"/> 
                    </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_email"  MaxLength="345" CssClass="form-control inputtext" placeholder="Email"/> 
                        </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_address"  MaxLength="255" CssClass="form-control inputtext" placeholder="Addresse"/> 
                        </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_postal"  MaxLength="20" CssClass="form-control inputtext" placeholder="Postnr"/> 
                        </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_country"  MaxLength="60" CssClass="form-control inputtext" placeholder="Land"/> 
                        </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_city"  MaxLength="60" CssClass="form-control inputtext" placeholder="By"/>
                        </div>
                    <asp:Button Text="Reservere Værelset" CssClass="RealBtn btn btn-light" ID="bn_reserve" OnClick="bn_reserve_Click" runat="server" />
                </div>
            </div>

            <!-- Second Colum, Data of Room and Info -->
            <div class="col-lg">

                <p ID="Label1" runat="server" OnLoad="Label1_Load"></p>
                </div>
            </div>
                  <div class="col-lg-1"></div>

        </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Order/OrderSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LandLyst.Order.WebForm1" %>

<script runat="server">

    protected void bn_reserveExist_Click(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="BgPic"></div>
    <div id="NavMenu" class="navBar">
        <div>
            <a href="..\">Forside</a>
            <a href="..\Booking">Book</a>
            <a href="..\test">Test</a>
            <i class="fa fa-times" onclick="NavBarFunc('0px', '0', '-150px')"></i>
        </div>
    </div>
    <a href="..\" style="text-decoration: none">
        <div class="headtitle">
        Hotel Landlyst
    </div>
    </a>
    <div class="menuClass">
        <button type="button" id="menuButton" onclick="NavBarFunc('150px', '1', '0px')" class="menuButton btn btn-light">
            <i class="fas fa-bars"></i> Menu
        </button>
    </div>
    <div class="container-fluid">
        <div class="row">
                  <div class="col-lg-1"></div>
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
            <div class="col-lg">

                <p ID="Label1" runat="server" OnLoad="Label1_Load"></p>
                </div>
            </div>
                  <div class="col-lg-1"></div>

        </div>
    </div>
</asp:Content>

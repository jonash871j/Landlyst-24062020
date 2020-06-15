<%@ Page Title="" Language="C#" MasterPageFile="~/Order/OrderSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LandLyst.Order.WebForm1" %>
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
    <div class="menuClass">
        <button type="button" id="menuButton" onclick="NavBarFunc('150px', '1', '0px')" class="menuButton btn btn-light">
            <i class="fas fa-bars"></i> Menu
        </button>
    </div>
    <div class="container-fluid">
        <div class="row">
                  <div class="col-sm-1"></div>
            <div class="col-sm">
                <Button type="button" class="btn btn-light" onclick="VeiwBox(1, 'NotNewCustomerBox', 'NewCustomerBox')">Ikke Tidligere Kunde</Button>
                <Button type="button" class="btn btn-light" onclick="VeiwBox(0, 'NotNewCustomerBox', 'NewCustomerBox')">Tidligere Kunde</Button>
                <div style="display:none;" id="NotNewCustomerBox">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control inputtext" placeholder="Email"/> 
                    </div>
                    <asp:Button Text="Reservere" ID="Button1" OnClick="bn_reserve_Click" runat="server" />

                </div>
                <div id="NewCustomerBox">
                    <div class="form-group" style="display: flex;">
                        <asp:TextBox runat="server" ID="tb_firstName" CssClass="form-control inputtext" placeholder="Fornavn"/>  
                        <asp:TextBox runat="server" ID="tb_lastName" CssClass="form-control inputtext" placeholder="Efternavn"/>  
                    </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_phoneNumber" CssClass="form-control inputtext" placeholder="Telefon nummer"/> 
                    </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_email" CssClass="form-control inputtext" placeholder="Email"/> 
                        </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_address" CssClass="form-control inputtext" placeholder="Addresse"/> 
                        </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_postal" CssClass="form-control inputtext" placeholder="Postnr"/> 
                        </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_country" CssClass="form-control inputtext" placeholder="Land"/> 
                        </div>
                    <div class="form-group">
                    <asp:TextBox runat="server" ID="tb_city" CssClass="form-control inputtext" placeholder="By"/>
                        </div>
                    <asp:Button Text="Reservere" ID="bn_reserve" OnClick="bn_reserve_Click" runat="server" />
                    <asp:Label runat="server" ID="lb_error" Text="[ERROR TEXT]"/>
                </div>
            </div>
            <div class="col-sm">
                <p>
                <%  Response.Write(Request["Room"] + " <br>");
                    Response.Write(Request["SDate"] + " <br>");
                    Response.Write(Request["LDate"] + " <br>");%>
                </p>
            </div>
                  <div class="col-sm-1"></div>

        </div>
    </div>
</asp:Content>

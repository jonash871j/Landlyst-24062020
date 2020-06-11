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
                <div class="form-group" style="display: flex;">
                    <asp:TextBox runat="server" CssClass="form-control inputtext" placeholder="Fornavn"/>  
                    <asp:TextBox runat="server" CssClass="form-control inputtext" placeholder="Efternavn"/>  
                </div>
                <div class="form-group">
                <asp:TextBox runat="server" CssClass="form-control inputtext" placeholder="Telefon nummer"/> 
                </div>
                <div class="form-group">
                <asp:TextBox runat="server" CssClass="form-control inputtext" placeholder="Email"/> 
                    </div>
                <div class="form-group">
                <asp:TextBox runat="server" CssClass="form-control inputtext" placeholder="Addresse"/> 
                    </div>
                <div class="form-group">
                <asp:TextBox runat="server" CssClass="form-control inputtext" placeholder="Postnr"/> 
                    </div>
                <div class="form-group">
                <asp:TextBox runat="server" CssClass="form-control inputtext" placeholder="By"/>
                    </div>
                <asp:Button Text="text" runat="server" />
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
    <script>
        function NavBarFunc(height, opacity, top) {
            document.getElementById("NavMenu").style.height = height;            
            document.getElementById("NavMenu").style.opacity = opacity;
            document.getElementById("NavMenu").style.top = top;
        }
    </script>
</asp:Content>

<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Booking/Booking.Master" CodeBehind="Default.aspx.cs" Inherits="LandLyst.Booking.Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="BgPic"></div>
    <div id="NavMenu" class="navBar">
        <div>
            <a href="..\">Forside</a>
            <a href="#">Book</a>
            <a href="..\test">Test</a>
            <i class="fa fa-times" onclick="NavBarFunc('0px', '0', '-150px')"></i>
        </div>
    </div>
        <div class="headtitle">
        Hotel Landlyst
    </div>
    <div class="menuClass">
        <button type="button" id="menuButton" onclick="NavBarFunc('150px', '1', '0px')" class="menuButton btn btn-light">
            <i class="fas fa-bars"></i> Menu
        </button>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-5">
                <div style="position: relative;
    top: 50%;
    transform: translate(0, -50%);">

                <%-- Calendar row --%>
                <div class="row calendar">
                    <div class="col-sm-6">
                        <%-- Start date calendar --%>
                        <h3>Start dato</h3>
                        <asp:Calendar ID="startDatePicker" SelectionMode="Day" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="sans-serif" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" FirstDayOfWeek="Default" OnSelectionChanged="startDatePicker_SelectionChanged">
                            <DayHeaderStyle BackColor="#f0f0f0" Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="White" />
                            <SelectedDayStyle BackColor="#578AFF" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#65717f" BorderColor="Black" Font-Bold="false" ForeColor="White" Font-Size="12pt" />
                            <TodayDayStyle BackColor="#9f9f9f" ForeColor="White" />
                            <WeekendDayStyle BackColor="White" />
                        </asp:Calendar>
                    </div>
                    <%-- End date calendar --%>
                    <div class="col-sm-6">
                        <h3>Slut dato</h3>
                        <asp:Calendar ID="endDatePicker" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="sans-serif" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="endDatePicker_SelectionChanged">
                            <DayHeaderStyle BackColor="#f0f0f0" Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="White" />
                            <SelectedDayStyle BackColor="#578AFF" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#65717f" BorderColor="Black" Font-Bold="false" ForeColor="White" Font-Size="12pt" />
                            <TodayDayStyle BackColor="#9f9f9f" ForeColor="White" />
                            <WeekendDayStyle BackColor="White" />
                        </asp:Calendar>
                    </div>
                </div>
                <%-- Row with room addition checkboxes --%>
                <%-- Not using asp:CheckBoxList since we can't get the design we want --%>

                <div class="CheckBoxDiv">


                    <label class="InputContainer">
                        <i class="fas fa-bed"></i>
                        Dobbeltseng
                <asp:CheckBox ID="DoubleBed" onclick="twoChecks(0, 'MainContent_DoubleBed', 'MainContent_TwoBeds')" runat="server" />
                        <span></span>
                    </label>

                    <label class="InputContainer">
                        <i class="fas fa-bed"></i><i class="fas fa-bed"></i>
                        2 enkelt senge
                <asp:CheckBox ID="TwoBeds" onclick="twoChecks(1, 'MainContent_DoubleBed', 'MainContent_TwoBeds')" runat="server" />
                        <span></span>
                    </label>
                    <label class="InputContainer">
                        <i class="fas fa-utensils"></i>
                        Køkken
                <asp:CheckBox ID="cb_kitchen" runat="server" />
                        <span></span>
                    </label>

                    <label class="InputContainer">
                        <i class="fas fa-hot-tub"></i>  
                        Jacuzzi
                <asp:CheckBox ID="cb_jacuzzi" runat="server" />
                        <span></span>
                    </label>

                    <label class="InputContainer">
                        <i class="fas fa-bath"></i>
                        Badekar
                <asp:CheckBox ID="cb_bathtub" runat="server" />
                        <span></span>
                    </label>

                    <label class="InputContainer">
                        <i class="fas fa-person-booth"></i>
                        Altan
                <asp:CheckBox ID="cb_balcony" runat="server" />
                        <span></span>
                    </label>
                    <br />
                    <asp:Button Text="Søg Værelser" runat="server" CssClass="btn btn-light" ID="SearchBtn" OnClick="SearchBtn_Click" Enabled="false" OnLoad="SearchBtn_Load"/>
                </div>
                </div>

            </div>
            <div class="col-lg-7 scrollmekanik">


                <%-- List with rooms --%>
                <asp:ListView runat="server" ID="RoomListView">
                    <LayoutTemplate>
                        <table>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </LayoutTemplate>
                    <%-- Creates a card for every available room --%>
                    <ItemTemplate>

                        <div class="roomCard">

                            <img class="roomCardImage" src="../Content/Image/HotelRoom.png" />

                            <div class="roomCardInformation">
                                <h4>Værelse: <%#Eval("Room") %> </h4>
                                <h5>Price: <%#Eval("Price") %></h5>
                                <p><%#Eval("Icons") %></p>
                            </div>
                            <div class="roomCardBTN">
                                <a href="..\Order\?Room=<%#Eval("Room")%>&SDate=<%Response.Write(startDatePicker.SelectedDate.ToString("dd-MM-yyyy"));%>&LDate=<%Response.Write(endDatePicker.SelectedDate.ToString("dd-MM-yyyy"));%>">
                                    BOOK NU
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
    </div>
</asp:Content>

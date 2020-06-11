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
    <div class="menuClass">
        <button type="button" id="menuButton" onclick="NavBarFunc('150px', '1', '0px')" class="menuButton btn btn-light">
            <i class="fas fa-bars"></i> Menu
        </button>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-5">
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
                        Køkken
                <asp:CheckBox ID="CheckBox1" runat="server" />
                        <span></span>
                    </label>

                    <label class="InputContainer">
                        Dobbeltseng
                <asp:CheckBox ID="CheckBox2" runat="server" />
                        <span></span>
                    </label>

                    <label class="InputContainer">
                        2 enkelt senge
                <asp:CheckBox ID="CheckBox3" runat="server" />
                        <span></span>
                    </label>

                    <label class="InputContainer">
                        Jacuzzi
                <asp:CheckBox ID="CheckBox4" runat="server" />
                        <span></span>
                    </label>

                    <label class="InputContainer">
                        Badekar
                <asp:CheckBox ID="CheckBox5" runat="server" />
                        <span></span>
                    </label>

                    <label class="InputContainer">
                        Altan
                <asp:CheckBox ID="CheckBox6" runat="server" />
                        <span></span>
                    </label>

                </div>

            </div>
            <div class="col-lg-7">


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
                                <h4>Værelse: <%#Eval("Room") %></h4>
                                <br />
                                <p><%#Eval("Icons") %></p>
                            </div>
                            <div class="roomCardBTN">
                                <a href="..\Order\?Room=<%#Eval("Room")%>&SDate=<%Response.Write(startDatePicker.SelectedDate.ToString());%>&LDate=<%Response.Write(endDatePicker.SelectedDate.ToString());%>">
                                    BOOK NU
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

            </div>
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

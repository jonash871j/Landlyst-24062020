<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Booking/Booking.Master" CodeBehind="Default.aspx.cs" Inherits="LandLyst.Booking.Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-5">
                <%-- Calendar row --%>
                <div class="row calendar">
                    <div class="col-sm-6">
                        <%-- Start date calendar --%>
                        <h3>Start dato</h3>
                        <asp:Calendar ID="startDatePicker" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </div>
                    <%-- End date calendar --%>
                    <div class="col-sm-6">
                        <h3>Slut dato</h3>
                        <asp:Calendar ID="endDatePicker" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
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

                <%--<div class="row informationBox">
                    <asp:TextBox runat="server" ReadOnly="true">Information om rum</asp:TextBox>

                </div>--%>
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
                                <h5>Værelse: <%#Eval("Room") %></h5>
                                <br />
                                <p><%#Eval("Icons") %></p>
                            </div>

                            <div class="roomCardBTN">
                                <button>BOOK NU</button>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
    </div>
</asp:Content>

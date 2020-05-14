<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LandLyst._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-5" style="border-right-style:solid; border-color:black;">

                <div class="row">
                    <div class="col-sm-6">
                        
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
                    <div class="col-sm-6" >
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
                <div class="row" style=" margin-top:20px">
                    <div class="col-sm-12">
                        
                        <asp:CheckBoxList runat="server" CssClass="radioButtonList" RepeatDirection="Horizontal" Font-Size="15px">
                            <asp:ListItem>Køkken</asp:ListItem>
                            <asp:ListItem>Dobbeltseng</asp:ListItem>
                            <asp:ListItem>2 enkelt senge</asp:ListItem>
                            <asp:ListItem>Jacuzzi</asp:ListItem>
                            <asp:ListItem>Badekar</asp:ListItem>
                            <asp:ListItem>Altan</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>

            </div>
            <div class="col-sm-7">
                <p>test</p>
            </div>

        </div>
    </div>

</asp:Content>

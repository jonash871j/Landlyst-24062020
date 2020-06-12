using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandLystLib;

namespace LandLyst.Booking
{
    public partial class Default : System.Web.UI.Page
    {
        private static Reception reception = new Reception("Server=127.0.0.1; Port=5432; User Id=postgres; Password=123; Database=Landlyst;");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void startDatePicker_SelectionChanged(object sender, EventArgs e)
        {
            if (startDatePicker.SelectedDate < DateTime.Today)
            {
                startDatePicker.SelectedDate = DateTime.Today;
            }
            else if ((startDatePicker.SelectedDate > endDatePicker.SelectedDate && endDatePicker.SelectedDate != new DateTime()) ||
                (startDatePicker.SelectedDate == endDatePicker.SelectedDate) && (endDatePicker.SelectedDate != new DateTime()))
            {
                startDatePicker.SelectedDate = new DateTime();
            }

        }

        protected void endDatePicker_SelectionChanged(object sender, EventArgs e)
        {
            if ((endDatePicker.SelectedDate < startDatePicker.SelectedDate && startDatePicker.SelectedDate != new DateTime()) ||
                (endDatePicker.SelectedDate < DateTime.Today) ||
                (endDatePicker.SelectedDate == startDatePicker.SelectedDate && startDatePicker.SelectedDate != new DateTime()))
            {
                endDatePicker.SelectedDate = new DateTime();
            }
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            List<int> roomNumbers = reception.GetRoomNumbers();
            SearchResult[] searchResult = new SearchResult[roomNumbers.Count];

            for (int i = 0; i < roomNumbers.Count; i++)
                searchResult[i] = new SearchResult(reception.GetRoom(roomNumbers[i]), (int)(endDatePicker.SelectedDate - startDatePicker.SelectedDate).TotalDays);
            RoomListView.DataSource = searchResult;
            RoomListView.DataBind();
        }
    }

    class SearchResult
    {
        List<string> additions = new List<string>();

        public int Room { get; private set; }
        public string Price { get; private set; }
        public string Icons
        {
            get
            {
                string icons = "";
                for (int i = 0; i < additions.Count; i++)
                {
                    switch (additions[i])
                    {
                        case "Altan": icons += $"{(char)0xf756} "; continue;
                        case "Dobbeltseng": icons += $"{(char)0xf236} "; continue;
                        case "2 enkeltsenge": icons += $"{(char)0xf236}{(char)0xf236} "; continue;
                        case "Badekar": icons += $"{(char)0xf2cd} "; continue;
                        case "Jacuzzi": icons += $"{(char)0xf593} "; continue;
                        case "Eget køkken": icons += $"{(char)0xf517} "; continue;
                        default: continue;
                    }
                }
                return icons;
            }
        }
        public SearchResult(Room room, int days)
        {
            Room = room.Number;
            Price = room.GetTotalPrice(days);
            for (int i = 0; i < room.Additions.Count; i++)
                additions.Add(room.Additions[i].Addtion);
        }
    }
}
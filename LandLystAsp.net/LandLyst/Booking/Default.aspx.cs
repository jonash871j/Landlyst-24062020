using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandLyst.Booking
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Example of data binding
            SearchResult sr = new SearchResult();
            sr.Room = 12;
            sr.Additions = new bool[6];
            sr.Additions[0] = true;
            SearchResult sr2 = new SearchResult();
            sr2.Room = 54;
            sr2.Additions = new bool[6];
            sr2.Additions[0] = true;
            sr2.Additions[1] = true;
            sr2.Additions[2] = true;
            sr2.Additions[3] = true;
            sr2.Additions[4] = true;
            sr2.Additions[5] = true;
            List<SearchResult> list = new List<SearchResult>();
            list.Add(sr);
            list.Add(sr2);
            RoomListView.DataSource = list;
            RoomListView.DataBind();
        }

        protected void startDatePicker_SelectionChanged(object sender, EventArgs e)
        {
            if (startDatePicker.SelectedDate < DateTime.Today)
            {
                startDatePicker.SelectedDate = DateTime.Today;
            }

            if ((startDatePicker.SelectedDate > endDatePicker.SelectedDate) && (endDatePicker.SelectedDate != new DateTime()))
            {
                DateTime date = endDatePicker.SelectedDate;
                date = date.AddDays(-7);
                startDatePicker.SelectedDate = date;
            }

        }

        protected void endDatePicker_SelectionChanged(object sender, EventArgs e)
        {
            if (endDatePicker.SelectedDate > startDatePicker.SelectedDate.AddMonths(1))
            {
                endDatePicker.SelectedDate = startDatePicker.SelectedDate.AddMonths(1);
            }

            if (endDatePicker.SelectedDate < startDatePicker.SelectedDate && (startDatePicker.SelectedDate != new DateTime()))
            {
                DateTime date = startDatePicker.SelectedDate;
                date = date.AddDays(7);
                endDatePicker.SelectedDate = date;
            }
        }
    }

    class SearchResult
    {
        public int Room { get; set; }
        public bool[] Additions { get; set; }
        public string Icons
        {
            get
            {
                //Makes a string with all the icons needed.
                string iconString = "";
                if (Additions[0] == true)
                {
                    iconString += $"{(char)0xf756} ";
                }
                if (Additions[1] == true)
                {
                    iconString += $"{(char)0xf236} ";
                }
                if (Additions[2] == true)
                {
                    iconString += $"{(char)0xf236} ";
                }
                if (Additions[3] == true)
                {
                    iconString += $"{(char)0xf2cd} ";
                }
                if (Additions[4] == true)
                {
                    iconString += $"{(char)0xf593} ";
                }
                if (Additions[5] == true)
                {
                    iconString += $"{(char)0xf517} ";
                }

                return iconString;
            }
        }

    }
}
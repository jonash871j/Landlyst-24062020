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
            sr.Additions = 1;
            SearchResult sr2 = new SearchResult();
            sr2.Room = 54;
            sr2.Additions = 2;
            List<SearchResult> list = new List<SearchResult>();
            list.Add(sr);
            list.Add(sr2);
            RoomListView.DataSource = list;
            RoomListView.DataBind();
        }
    }

    class SearchResult
    {
        public int Room { get; set; }
        public int Additions { get; set; }
        public string Icons
        {
            get
            {
                string iconString = "";
                if (Additions == 1)
                {
                    iconString += $"{(char)0xf236} ";
                }
                if (Additions == 2)
                {
                    iconString += $"{(char)0xf042} ";
                }
                if (Additions == 3)
                {
                    iconString += $"{(char)0xf042} ";
                }
                if (Additions == 4)
                {
                    iconString += $"{(char)0xf042} ";
                }
                if (Additions == 5)
                {
                    iconString += $"{(char)0xf042} ";
                }
                if (Additions == 6)
                {
                    iconString += $"{(char)0xf042} ";
                }

                return iconString;
            }
        }
    }
}
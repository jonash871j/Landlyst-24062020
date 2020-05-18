using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
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
            sr.Title = "jens";
            sr.Path = "2r3wrwe";
            List<SearchResult> list = new List<SearchResult>();
            list.Add(sr);
            //RoomListView.DataSource = list;
            //RoomListView.DataBind();
        }
    }

    class SearchResult
    {
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
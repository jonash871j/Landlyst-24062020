using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandLystLib;

namespace LandLyst.Order
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Reception reception = new Reception("Server=127.0.0.1; Port=5432; User Id=postgres; Password=123; Database=Landlyst;");
            List<int> roomnumbers = reception.GetRoomNumbers();
        }
    }
}
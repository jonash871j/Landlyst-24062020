using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeatsStore__CSharp_03122019.MeatsStore
{
    public partial class GameBasket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lb_username.Text = GlobalUser.Username;
            lb_balance.Text = "Balance " + GlobalUser.Balance.ToString() + " DKK";
        }
    }
}
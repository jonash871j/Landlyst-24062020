using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeatsStore__CSharp_03122019.MeatsStore
{
    public partial class AddMoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lb_username.Text = GlobalUser.Username;
            lb_balance.Text = "Balance " + GlobalUser.Balance.ToString() + " DKK";
        }

        protected void bn_addMoney_Click(object sender, EventArgs e)
        {
            int a;
            try
            {
                a = Convert.ToInt32(tb_balanceBox.Text);
            }
            catch(Exception exception) { return; };
            if (a > 500)
                return;
            GlobalUser.Balance += a;
            lb_balance.Text = "Balance " + GlobalUser.Balance.ToString() + " DKK";
        }
    }
}
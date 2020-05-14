using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MeatsStore__CSharp_03122019.MeatsStore
{
    public partial class MeatsStoreMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (GlobalUser.IsUserLogined == false)
            //    Response.Redirect("../Login/LoginMain.aspx");

            lb_username.Text = GlobalUser.Username;
            lb_balance.Text = "Balance " + GlobalUser.Balance.ToString() + " DKK";


            // Show game table
            GameTable gameTable = new GameTable(tb_gameTable);
            gameTable.ShowTable();
        }
    }
}
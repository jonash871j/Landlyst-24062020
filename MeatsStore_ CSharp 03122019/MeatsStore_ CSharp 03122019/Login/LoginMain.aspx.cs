using System;
using System.Web.UI;

namespace MeatsStore__CSharp_03122019
{
    public partial class _Default : Page
    {
        UserSystem login = new UserSystem();

        protected void Page_Load(object sender, EventArgs e)
        {
            lb_errAcountInvalid.Visible = false;
            GlobalUser.Logout();
        }

        // Used to login
        protected void bn_logIn_Click(object sender, EventArgs e)
        {
            if (login.CheckLogin(tb_username.Text, tb_password.Text))
            {
                GlobalUser.IsUserLogined = true;
                GlobalUser.Username = tb_username.Text;
                Response.Redirect("../MeatsStore/MeatsStoreMain.aspx");
                return;
            }
            lb_errAcountInvalid.Visible = true;
        }

        // Used to signup
        protected void bn_signUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginSignup.aspx");   
        }
    }
}
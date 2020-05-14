using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeatsStore__CSharp_03122019.Login
{
    public partial class LoginSignup : System.Web.UI.Page
    {
        UserSystem signup = new UserSystem();

        protected void Page_Load(object sender, EventArgs e)
        {
            ResetErrorMessages();

        }

        protected void bn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginMain.aspx");
        }

        protected void bn_signUp_Click(object sender, EventArgs e)
        {
            ResetErrorMessages();

            // Check if username is empty
            if (tb_username.Text == "")
            { 
                lb_errUsernameInvalid.Visible = true; 
                return; 
            }

            // Check if don't password match
            if (tb_password.Text != tb_passwordChecker.Text) 
            { 
                lb_errPasswordDontMatch.Visible = true; 
                return; 
            }

            // Check if password is to short
            if (tb_password.Text.Length < 8) 
            { 
                lb_errPasswordToShort.Visible = true; 
                return; 
            }

            // Check if password is to long
            if (tb_password.Text.Length > 50)
            { 
                lb_errPasswordToLong.Visible = true; 
                return; 
            }

            // Signup the user
            if (signup.CheckSignUp(tb_username.Text, tb_password.Text))
                Response.Redirect("LoginMain.aspx");
            else
                lb_errUsernameInvalid.Visible = true;
        }

        // Hides errors
        private void ResetErrorMessages()
        {
            lb_errUsernameInvalid.Visible = false;
            lb_errPasswordDontMatch.Visible = false;
            lb_errPasswordToShort.Visible = false;
            lb_errPasswordToLong.Visible = false;
        }
    }
}
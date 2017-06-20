using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fatnisse
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (DBHelper.CheckUser(email, txtPassword.Text.Trim()))
            {
                //Setting custom cookie that we can extract email from
                FormsAuthentication.SetAuthCookie(email, true);

                string returnUrl = Request.QueryString["ReturnUrl"] as string;
                if (returnUrl != null)
                {
                    Response.Redirect(returnUrl);
                }
                else
                {
                    //no return URL specified so lets kick him to home page
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                //Login failed
            }
        }
    }
}
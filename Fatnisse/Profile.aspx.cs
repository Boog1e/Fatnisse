using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fatnisse
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DBHelper.CheckAuth())
            {
                Response.Redirect("Login.aspx?ReturnUrl=Profile.aspx");
            }
            else
            {
                string email = HttpContext.Current.User.Identity.Name;
                User user = DBHelper.GetUser(email);
                if (user.id != 0 && user.id != null)
                {
                    btnLogin.Visible = false;
                    navbar.InnerHtml = "<span> Welcome, " + user.firstName + " " + user.lastName + "</span>";
                    txtEmail.Text = user.email;
                    txtPhone.Text = user.phone;
                }
                else
                {
                    Response.Redirect("Login.aspx?ReturnUrl=Profile.aspx");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fatnisse
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DBHelper.CheckAuth())
            {
                //Do nothing just show the frontpage
            }
            else
            {
                string email = HttpContext.Current.User.Identity.Name;
                User user = DBHelper.GetMemberFromEmail(email);
                if (user.id != 0 && user.id != null)
                {
                    if (!IsPostBack)
                    {
                        //Change navbar information to fit logged in user
                        btnLogin.Visible = false;
                        navbar.InnerHtml = "<ul class='nav navbar-nav navbar-right' runat='server'><li><a href='Profile.aspx'>Profile</a></li><li><a href='Teams.aspx'>Courses</a></li><li><a href='Subscribe.aspx'>Subscription</a></li></ul>";
                    }
                }
                else
                {
                    //Just show the frontpage
                }
            }
        }
    }
}

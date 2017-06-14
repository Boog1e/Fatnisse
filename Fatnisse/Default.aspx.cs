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
                        btnLogin.Visible = false;
                        navbar.InnerHtml = "<span>Welcome, <a href='Profile.aspx'>" + user.firstName + " " + user.lastName + "</a></span>";
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
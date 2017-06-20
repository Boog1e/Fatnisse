using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Fatnisse
{
    public partial class Subscribe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DBHelper.CheckAuth())
            {
                Response.Redirect("Login.aspx?ReturnUrl=Subscribe.aspx");
            }
            else
            {
                string email = HttpContext.Current.User.Identity.Name;
                User user = DBHelper.GetMemberFromEmail(email);
                if (user.id != 0 && user.id != null)
                {
                    //Change navbar information to logged in user
                    btnLogin.Visible = false;
                    navbar.InnerHtml = "<ul class='nav navbar-nav navbar-right' runat='server'><li><a href='Profile.aspx'>Profile</a></li><li><a href='Teams.aspx'>Courses</a></li><li><a href='Subscribe.aspx'>Subscription</a></li></ul>";

                    //All subscriptions user is assigned to
                    List<Subscription> allSubsOnUser = DBHelper.GetSubscriptionFromUser(user.id.ToString());
                    foreach (Subscription sub in DBHelper.GetSubscriptions())
                    {
                        //If user isnt a part of the subscription plan, he can see it otherwise not (it can be viewed under profile.aspx
                        if (!allSubsOnUser.Any(item => item.id == sub.id))
                        {
                            HtmlGenericControl div = new HtmlGenericControl("div");
                            div.Attributes.Add("style", "float:left;color:black;border: 1px solid;padding:5px;width:100%;margin-bottom:3px;");
                            div.Attributes.Add("class", "roundCorners");

                            Label lbl = new Label();
                            lbl.Text = sub.name + " - " + sub.price.ToString();
                            lbl.Attributes.Add("style", "float:left;");
                            div.Controls.Add(lbl);

                            Button b = new Button();
                            b.ID = sub.id.ToString();
                            b.Text = "Subscribe";
                            b.Attributes.Add("style", "float:right;");
                            b.Attributes.Add("class", "roundCorners btn-success");
                            b.Click += new EventHandler(b_Click);
                            div.Controls.Add(b);

                            divSubscriptions.Controls.Add(div);
                        }
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx?ReturnUrl=Subscribe.aspx");
                }
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            User user = DBHelper.GetMemberFromEmail(HttpContext.Current.User.Identity.Name);
            if (btnClicked.Text == "Subscribe")
            {
                if (DBHelper.AddUserToSubscription(user.id.ToString(), btnClicked.ID))
                {
                    Response.Redirect("Subscribe.aspx");
                }
                else
                {
                    //Error
                }
            }
        }
    }
}
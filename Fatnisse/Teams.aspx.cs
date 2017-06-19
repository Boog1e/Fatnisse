using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Fatnisse
{
    public partial class Teams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DBHelper.CheckAuth())
            {
                Response.Redirect("Login.aspx?ReturnUrl=Teams.aspx");
            }
            else
            {
                string email = HttpContext.Current.User.Identity.Name;
                User user = DBHelper.GetMemberFromEmail(email);
                if (user.id != 0 && user.id != null)
                {
                    btnLogin.Visible = false;
                    navbar.InnerHtml = "<ul class='nav navbar-nav navbar-right' runat='server'><li><a href='Profile.aspx'>Profile</a></li><li><a href='Teams.aspx'>Courses</a></li><li><a href='Subscribe.aspx'>Subscription</a></li></ul>";

                    List<Team> coursesFromUser = DBHelper.GetTeamFromUser(user.id.ToString());
                    foreach (Team team in DBHelper.GetTeams())
                    {
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes.Add("style", "float:left;color:black;border: 1px solid;padding:5px;width:100%;margin-bottom:3px;");
                        div.Attributes.Add("class", "roundCorners");

                        Label lbl = new Label();
                        lbl.Text = team.name;
                        lbl.Attributes.Add("style", "float:left;");
                        div.Controls.Add(lbl);

                        if (!coursesFromUser.Any(item => item.id == team.id))
                        {
                            Button b = new Button();
                            b.ID = team.id.ToString();
                            b.Text = "Subscribe";
                            b.Attributes.Add("style", "float:right;");
                            b.Attributes.Add("class", "roundCorners btn-success");
                            b.Click += new EventHandler(b_Click);
                            div.Controls.Add(b);
                        }
                        else
                        {
                            Button b = new Button();
                            b.ID = team.id.ToString();
                            b.Text = "Remove";
                            b.Attributes.Add("style", "float:right;");
                            b.Attributes.Add("class", "roundCorners btn-danger");
                            b.Click += new EventHandler(b_Click);
                            div.Controls.Add(b);
                        }

                        divTeams.Controls.Add(div);
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx?ReturnUrl=Teams.aspx");
                }
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            User user = DBHelper.GetMemberFromEmail(HttpContext.Current.User.Identity.Name);
            if(btnClicked.Text == "Remove")
            {
                if(DBHelper.RemoveUserFromTeam(user.id.ToString(), btnClicked.ID))
                {
                    Response.Redirect("Teams.aspx");
                }
                else
                {
                    //Error
                }
            }
            else
            {
                if (DBHelper.AddUserToTeam(btnClicked.ID, user.id.ToString()))
                {
                    //Assigned course
                    Response.Redirect("Teams.aspx");
                }
                else
                {
                    //Error
                }
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
                User user = DBHelper.GetMemberFromEmail(email);
                if (user.id != 0 && user.id != null)
                {
                    if (!IsPostBack)
                    {
                        btnLogin.Visible = false;
                        navbar.InnerHtml = "<ul class='nav navbar-nav navbar-right' runat='server'><li><a href='Profile.aspx'>Profile</a></li><li><a href='Teams.aspx'>Courses</a></li><li><a href='Subscribe.aspx'>Subscription</a></li></ul>";
                        txtEmail.Text = user.email;
                        txtPhone.Text = user.phone;
                        txtFirstname.Text = user.firstName;
                        txtLastname.Text = user.lastName;
                        hdnID.Value = user.id.ToString(); 
                    }

                    divCourses.InnerHtml = "";

                    List<Team> courses = DBHelper.GetTeamFromUser(user.id.ToString());
                    foreach (Team course in courses)
                    {
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes.Add("style", "float:left;color:black;border: 1px solid;padding:5px;width:100%;margin-bottom:3px;");
                        div.Attributes.Add("class", "roundCorners");

                        Label lbl = new Label();
                        lbl.Text = course.name;
                        lbl.Attributes.Add("style", "float:left;");
                        div.Controls.Add(lbl);

                        Button b = new Button();
                        b.ID = course.id.ToString() + "_course";
                        b.Text = "Remove";
                        b.Attributes.Add("style", "float:right;");
                        b.Attributes.Add("class", "roundCorners btn-danger");
                        b.Click += new EventHandler(b_Click);
                        div.Controls.Add(b);

                        divCourses.Controls.Add(div);
                    }

                    List<Subscription> GetAllSubs = DBHelper.GetSubscriptionFromUser(user.id.ToString());
                    foreach (Subscription sub in GetAllSubs)
                    {
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes.Add("style", "float:left;color:black;border: 1px solid;padding:5px;width:100%;margin-bottom:3px;");
                        div.Attributes.Add("class", "roundCorners");

                        Label lbl = new Label();
                        lbl.Text = sub.name;
                        lbl.Attributes.Add("style", "float:left;");
                        div.Controls.Add(lbl);

                        Button b = new Button();
                        b.ID = sub.id.ToString() + "_sub";
                        b.Text = "Remove";
                        b.Attributes.Add("style", "float:right;");
                        b.Attributes.Add("class", "roundCorners btn-danger");
                        b.Click += new EventHandler(a_Click);
                        div.Controls.Add(b);

                        divSubscription.Controls.Add(div);
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx?ReturnUrl=Profile.aspx");
                }
            }
        }

        private void a_Click(object sender, EventArgs e)
        {
            //Remove my subscription
            Button btnClicked = (Button)sender;
            if (DBHelper.RemoveUserFromSubscription(hdnID.Value, btnClicked.ID.ToString().Replace("_sub", "")))
            {
                //Removed
                Response.Redirect("Profile.aspx");
            }
            else
            {

            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Edit userinformation
            if (DBHelper.UpdateUser(hdnID.Value.ToString(), txtFirstname.Text, txtLastname.Text, txtPhone.Text, txtEmail.Text))
            {
                User user = DBHelper.GetMemberFromID(hdnID.Value.ToString());
                txtFirstname.Text = user.firstName;
                txtLastname.Text = user.lastName;
                txtPhone.Text = user.phone;
                txtEmail.Text = user.email;
                navbar.InnerHtml = "<span>Welcome, <a href='Profile.aspx'>" + user.firstName + " " + user.lastName + "</a></span><a id='linkTeams' runat='server' href='Teams.aspx'>Courses</a>";
                btnLogin.Visible = false;
            }
            else
            {
                //Error
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if(DBHelper.ChangePassword(txtOldPassword.Text, txtNewPassword.Text, hdnID.Value))
            {
                //Password changed
            }
            else
            {
                //Something went wrong
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            //Remove me from team
            Button btnClicked = (Button)sender;
            if (DBHelper.RemoveUserFromTeam(hdnID.Value, btnClicked.ID.ToString().Replace("_course", "")))
            {
                //Removed
                Response.Redirect("Profile.aspx");
            }
            else
            {

            }
        }
    }
}
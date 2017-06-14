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
                User user = DBHelper.GetMemberFromEmail(email);
                if (user.id != 0 && user.id != null)
                {
                    if (!IsPostBack)
                    {
                        btnLogin.Visible = false;
                        navbar.InnerHtml = navbar.InnerHtml = "<span>Welcome, <a href='Profile.aspx'>" + user.firstName + " " + user.lastName + "</a></span>";
                        txtEmail.Text = user.email;
                        txtPhone.Text = user.phone;
                        txtFirstname.Text = user.firstName;
                        txtLastname.Text = user.lastName;
                        hdnID.Value = user.id.ToString();
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx?ReturnUrl=Profile.aspx");
                }
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
                navbar.InnerHtml = navbar.InnerHtml = "<span>Welcome, <a href='Profile.aspx'>" + user.firstName + " " + user.lastName + "</a></span>";
                btnLogin.Visible = false;
            }
            else
            {
                //Error
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {

        }
    }
}
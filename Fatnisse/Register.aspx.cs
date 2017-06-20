using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fatnisse
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Check if regex is email matching
            if (Regex.IsMatch(txtEmail.Text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                //Check if phone number is danish
                if (true)
                {
                    //Create user
                    bool created = DBHelper.CreateUser(txtFirstname.Text, txtLastname.Text, txtPhone.Text, txtEmail.Text, txtPassword.Text);
                    if (created)
                        Response.Redirect("Login.aspx");
                }
                else
                {
                    //Incorrect phone number
                }
            }
            else
            {
                //Incorrect email
            }
        }
    }
}
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
            foreach (Team team in DBHelper.GetTeams())
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("style", "float:left;color:black;border: 1px solid;padding:5px;width:100%;margin-bottom:3px;");
                div.Attributes.Add("class", "roundCorners");

                Label lbl = new Label();
                lbl.Text = team.name;
                lbl.Attributes.Add("style", "float:left;");
                div.Controls.Add(lbl);

                Button b = new Button();
                b.ID = team.id.ToString();
                b.Text = "Tilmeld";
                b.Attributes.Add("style", "float:right;");
                b.Attributes.Add("class", "roundCorners btn-success");
                b.Click += new EventHandler(b_Click);
                div.Controls.Add(b);

                divTeams.Controls.Add(div);
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;

            User user = DBHelper.GetMemberFromEmail(HttpContext.Current.User.Identity.Name);
            if (DBHelper.AddUserToTeam(btnClicked.ID, user.id.ToString()))
            {
                //Du er nu tilmeldt
            }
            else
            {
                //Fejl
            }

        }

    }
}
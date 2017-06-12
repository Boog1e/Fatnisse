using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;

public class DBHelper
{
    public static bool CheckUser(string email, string password)
    {
        var json = "";

        using (WebClient web = new WebClient())
        {
            //Getting json data from web-service
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/CheckLogin?email=" + email + "&password=" + password);
        }

        if (json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);
            if (jObject != null)
            {
                if (jObject["Success"].ToString() == "True")
                    return true;
                else
                    return false;
            }
        }
        return false;
    }

    public static bool CheckAuth()
    {
        string email = HttpContext.Current.User.Identity.Name;
        if (email != null && email != "")
            return true;
        else
            return false;
    }

    public static User GetUser(string email)
    {
        var json = "";
        User user = new User();

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/GetMemberFromEmail?email=" + email);
        }

        if(json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);
            if(jObject != null)
            {
                user.id = Convert.ToInt32(jObject["Response"]["id"]);
                user.firstName = jObject["Response"]["firstName"].ToString();
                user.lastName = jObject["Response"]["lastName"].ToString();
                user.phone = jObject["Response"]["phone"].ToString();
                user.email = jObject["Response"]["email"].ToString();
            }
        }

        return user;
    }
}
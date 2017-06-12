using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public class DBHelper
{
    public static bool CheckUser(string email, string password)
    {
        return true;
    }

    public static bool CheckAuth()
    {
        string email = HttpContext.Current.User.Identity.Name;

        if (email != null && email != "")
            return true;
        else
            return false;
    }
}
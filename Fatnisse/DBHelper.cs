﻿using Newtonsoft.Json.Linq;
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

    public static bool CreateTeam(string name)
    {
        var json = "";

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/CreateTeam?name=" + name);
        }

        if (json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);

            if (jObject["Success"].ToString() == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }


    public static bool CreateUser(string firstName, string lastName, string phone, string email, string password)
    {
        var json = "";

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/CreateUser?firstname=" + firstName + "&lastname=" + lastName + "&phone=" + phone + "&email=" + email + "&password=" + password);
        }

        if(json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);

            if(jObject["Success"].ToString() == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public static bool DeleteSubscriptionFromName(string name)
    {
        var json = "";

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/DeleteSubscriptionFromName?name=" + name);
        }

        if (json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);

            if (jObject["Success"].ToString() == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public static bool DeleteUserFromID(string id)
    {
        var json = "";

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/DeleteUserFromID?id=" + id);
        }

        if (json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);

            if (jObject["Success"].ToString() == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public static User GetMemberFromEmail(string email)
    {
        var json = "";
        User user = new User();

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/GetMemberFromEmail?email=" + email);
        }

        if (json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);
            if (jObject != null)
            {
                if (jObject["Success"].ToString() == "True")
                {
                    user.id = Convert.ToInt32(jObject["Response"]["id"]);
                    user.firstName = jObject["Response"]["firstName"].ToString();
                    user.lastName = jObject["Response"]["lastName"].ToString();
                    user.phone = jObject["Response"]["phone"].ToString();
                    user.email = jObject["Response"]["email"].ToString();
                }
            }
        }

        return user;
    }

    public static User GetMemberFromID(string id)
    {
        var json = "";
        User user = new User();

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/GetMemberFromId?id=" + id);
        }

        if (json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);
            if (jObject != null)
            {
                if(jObject["Success"].ToString() == "True")
                {
                    user.id = Convert.ToInt32(jObject["Response"]["id"]);
                    user.firstName = jObject["Response"]["firstName"].ToString();
                    user.lastName = jObject["Response"]["lastName"].ToString();
                    user.phone = jObject["Response"]["phone"].ToString();
                    user.email = jObject["Response"]["email"].ToString();
                }
            }
        }

        return user;
    }

    public static List<User> GetMembers()
    {
        var json = "";
        List<User> users = new List<User>();

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/GetMembers");
        }

        if(json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);
            if(jObject != null)
            {
                if(jObject["Success"].ToString() == "True")
                {
                    foreach (JObject obj in jObject["Response"])
                    {
                        users.Add(new User()
                        {
                            id = Convert.ToInt32(obj["id"]),
                            firstName = obj["firstName"].ToString(),
                            lastName = obj["lastName"].ToString(),
                            phone = obj["phone"].ToString(),
                            email = obj["email"].ToString()
                        });
                    }
                }
            }
        }

        return users;
    }

    public static List<Team> GetTeams()
    {
        var json = "";
        List<Team> teams = new List<Team>();

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/GetTeams");
        }

        if (json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);
            if (jObject != null)
            {
                if (jObject["Success"].ToString() == "True")
                {
                    foreach (JObject obj in jObject["Response"])
                    {
                        teams.Add(new Team()
                        {
                            id = Convert.ToInt32(obj["id"]),
                            name = obj["name"].ToString()
                        });
                    }
                }
            }
        }

        return teams;
    }

    public static bool UpdateUser(string id, string firstname, string lastname, string phone, string email)
    {
        var json = "";

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/UpdateUser?id=" + id + "&firstname=" + firstname + "&lastname=" + lastname + "&phone=" + phone + "&email=" + email);
        }

        if(json != "" && json != null)
        {
            JObject jObject = JObject.Parse(json);
            if(jObject != null)
            {
                if(jObject["Success"].ToString() == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }

    public static bool AddUserToTeam(string teamId, string userId)
    {
        var json = "";

        using (WebClient web = new WebClient())
        {
            json = web.DownloadString("http://jako34982.web.techcollege.dk/WebService.asmx/AddUserToTeam?userId=" + userId + "&teamId=" + teamId);
        }

        if(json != "" && json != null)
        {
            JObject jOjbect = JObject.Parse(json);
            if(jOjbect != null)
            {
                if(jOjbect["Success"].ToString() == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }
}
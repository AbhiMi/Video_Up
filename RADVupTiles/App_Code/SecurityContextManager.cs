using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for CookieManager
/// </summary>
public static class SecurityContextManager
{
    public static MembershipUser GetUserProfile(HttpContext context)
    {
        var authCookie = context.Request.Cookies["u"];
        var userName = FormsAuthentication.Decrypt(authCookie.Value).Name;
        var userProfile = LoginProvider.GetUserProfile(userName);
        //context.Items["Profile"] = userProfile;
        return userProfile;

    }

    public static bool IsAnonymous(HttpContext context)
    {
        return context.Request.Cookies["u"] == null;
    }
}
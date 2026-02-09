using System;
using System.Web;

namespace COMMON
{
    public class UserAuthentication
    {
        public bool SetCookie(string uid, string utype)
        {
            try
            {
                HttpCookie user = new HttpCookie("user");
                user.Values.Add("user_id", uid);
                user.Values.Add("user_type", utype);
                HttpContext.Current.Response.Cookies.Add(user);
            }

            catch (Exception e)
            {
                ExceptionLogging.SendErrorToText(e);
                return false;
            }
            return true;
        }
    }
}

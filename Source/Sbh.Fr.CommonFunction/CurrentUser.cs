using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Persada.Fr.CommonFunction
{
   public class CurrentUser : AuthorizeAttribute
    {
        public static int GetCurrentUserIdId()
        {
            if (HttpContext.Current.Session["USER_ID_ID"] != null)
            {
                return (int)HttpContext.Current.Session["USER_ID_ID"];
            }
            else
            {
                return 0;
            }
            AuthorizationContext filterContext;
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
        }

        public static string GetCurrentUserId()
        {
            if (HttpContext.Current.Session["USER_ID"] != null)
            {
                return HttpContext.Current.Session["USER_ID"].ToString();
            }
            else
            {
                return "";
            }            
        }

        public static bool IsSa()
        {
            if (HttpContext.Current.Session["IS_SUPER_ADMIN"] != null)
            {
                return (bool)HttpContext.Current.Session["IS_SUPER_ADMIN"];
            }
            else
            {
                return false;
            }
        }

        public static string GetCurrentEmail()
        {
            if (HttpContext.Current.Session["USER_EMAIL"] != null)
            {
                return HttpContext.Current.Session["USER_EMAIL"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static string GetCurrentName()
        {
            if (HttpContext.Current.Session["USER_NAME"] != null)
            {
                return HttpContext.Current.Session["USER_NAME"].ToString();
            }
            else
            {
                return "";
            }
        }
        
        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        public static string GetCurrentAppMap()
        {
            return HttpContext.Current.Server.MapPath("~/Attachments");
        }



        public static void IsLogin()
        {
            if (CurrentUser.GetCurrentUserId() == "")
            {
                AuthorizationContext filterContext = new AuthorizationContext();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }            
        }
    }
}

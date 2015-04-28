using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Indigo99.Web.Admin
{
        public class ConakryAdminAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var isAuthorized = System.Web.HttpContext.Current.Session["currentUser"] != null;
                if (!isAuthorized)
                {
                    return false;
                }

                return true;
            }
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(
                                new
                                {
                                    controller = "LogIn",
                                    action = "Index"
                                })
                            );

            }
        }
  
}
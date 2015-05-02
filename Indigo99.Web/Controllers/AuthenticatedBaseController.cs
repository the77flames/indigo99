using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Indigo99.Web.Controllers
{
    public class AuthenticatedBaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            CustomPrincipal principal = System.Web.HttpContext.Current.Session["currentUser"] as CustomPrincipal;
            var loggedInUser = principal == null ? null : principal.Customer as Customer;
            ViewBag.LoggedInUserEmail = loggedInUser.Email;

        }
     
       

    }
}

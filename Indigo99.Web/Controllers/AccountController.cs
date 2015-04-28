using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Indigo99.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private Customer loggedInUser;

     
        public AccountController()
        {
            CustomPrincipal principal = System.Web.HttpContext.Current.Session["currentUser"] as CustomPrincipal;
            loggedInUser = principal == null ? null : principal.Customer as Customer;
        }

        [IndigoAuthorize]
        public ActionResult Index()
        {
            
            return View(loggedInUser);
        }

    }
}

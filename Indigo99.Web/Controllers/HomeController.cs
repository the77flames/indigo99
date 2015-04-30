using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Indigo99.Web.Controllers
{
    public class HomeController : Controller
    {
       
        [HttpGet]
       // [OutputCache(Duration = 120)]
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult PreloginContestIndex()
        {
            if (System.Web.HttpContext.Current.Session["currentUser"] != null)
                return RedirectToAction("ContestIndex");

            return View();
        }

        [IndigoAuthorize]
        public ActionResult ContestIndex()
        {
            return View();
        }
        
      
    }
}

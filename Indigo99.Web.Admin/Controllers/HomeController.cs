using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Indigo99.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        [ConakryAdminAuthorize]
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult About()
        {           
            return View();
        }

        public ActionResult Contact()
        {          
            return View();
        }
    }
}

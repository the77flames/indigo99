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
    public class GistController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {            
            return View();
        }

        
      
    }
}

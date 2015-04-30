using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Indigo99.Controllers
{
    public class LogInController : Controller
    {
        private IAuthenticationService _authenticationService;

        public LogInController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpGet]
        [OutputCache(Duration = 86400)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> TryLogIn(string email, string passWord)
        {           
            if (_authenticationService.Authenticate(email, passWord))
            {
                await LogInUser(email);
                return Json(true);
            }

            throw new UnauthorizedAccessException("Bad username or password");
        }


        private async Task LogInUser(string email)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;

            //authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var claims = new List<Claim> { new Claim("email", email) };
            var identity = new ClaimsIdentity(claims);

            await Task.Factory.StartNew( () => authenticationManager.SignIn(
                new AuthenticationProperties()
                {
                    IsPersistent = false
                }, identity));

                        
        }

        public ActionResult SignOut()
        {           
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            System.Web.HttpContext.Current.Session["currentUser"] = null;
            System.Web.HttpContext.Current.Session.Abandon();
            return RedirectToAction("Index", "Home");
                
        }




    }
}

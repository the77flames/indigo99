using Indigo99.BusinessServices;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Indigo99.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private static ICustomerManagementService _customerManagementService;
        private static IAddressManagementService _addressManagementService;
        public RegistrationController(ICustomerManagementService customerManagementService, IAddressManagementService addressManagementService)
        {
            _customerManagementService = customerManagementService;
            _addressManagementService = addressManagementService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult CheckEmailExist(string email)
        {
            return Json(_customerManagementService.CheckCustomerExist(email), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Register(string firstname, string lastname, string email, 
                                    string month, string year, string day, string password)
        {
            var dateofbirth = new DateTime();
            var dob = month + "/" + day + "/" + year;
            DateTime.TryParse(dob, out dateofbirth);
            var customer = new Customer
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Password = password,
                    DOB = dateofbirth,                    
                };
            try
            {
                
                _customerManagementService.Enroll(customer);
                customer = _customerManagementService.GetCustomerByEmail(email);
                _addressManagementService.AddNewAddress(new CustomerAddress { CustomerID = customer.Id  });
                return RedirectToAction("Home", "ContestIndex");
            }
            catch (Exception)
            {
                if (customer != null)
                    _customerManagementService.RemoveCustomer(customer.Id.ToString());
                return RedirectToAction("Index");
            }

        }
    }
}

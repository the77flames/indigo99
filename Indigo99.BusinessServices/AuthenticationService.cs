using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indigo99.Data;
using Indigo99.DomainObjects;
using System.Security.Principal;
using System.Threading;

namespace Indigo99.BusinessServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private static CustomerRepository _customerRepository;
        private static AdminUserRepository _adminUserRepository;

        public AuthenticationService(CustomerRepository customerRepository, AdminUserRepository adminUserRepository)
        {
            _customerRepository = new CustomerRepository();
            _adminUserRepository = new AdminUserRepository();
        }

        public bool Authenticate(string UserName, string Password, bool IsAdmin = false)
        {
            var customer = !IsAdmin ? _customerRepository.GetCustomerByUserNamePassword(UserName, Password) as IPerson : _adminUserRepository.GetAdminUser(UserName, Password);
            if (customer == null)
                return false;
            CustomPrincipal principal = new CustomPrincipal(new GenericIdentity(customer.Email, "User"), new string[] { "User" });
            principal.Customer = customer;            
            System.Web.HttpContext.Current.Session["currentUser"] = principal;
            return true;
        }

       
    }
}

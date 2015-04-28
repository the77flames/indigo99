using Indigo99.Data;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.BusinessServices
{
    public class CustomerManagementService : ICustomerManagementService
    {
        private CustomerRepository _customerRepository;

        public CustomerManagementService(CustomerRepository cusotmerRepository)
        {
            _customerRepository = cusotmerRepository;
        }
        
        public void Enroll(Customer newCustomer)
        {
            _customerRepository.Create(newCustomer);
        }

        public bool CheckCustomerExist(string email)
        { 
           return _customerRepository.GetCustomerByEmail(email) != null;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.GetCustomerByEmail(email);
        }

        public void RemoveCustomer(string id)
        {
            _customerRepository.Delete(id);
        }

    }
}

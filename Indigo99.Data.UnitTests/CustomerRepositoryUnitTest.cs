using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indigo99.DomainObjects;

namespace Indigo99.Data.UnitTests
{
    [TestClass]
    public class CustomerRepositoryUnitTest
    {
        private CustomerRepository _customerRepository;

        public CustomerRepositoryUnitTest()
        {
            _customerRepository = new CustomerRepository();
        }

        [TestMethod]
        public void CustomerRepositoryCreateTest()
        {
            var customerID = (int)new Random().Next(10000, 3000000);
            var customer = new Customer
            {
                Email ="uncleKay@okayhouse.com",
                Password="password",
                FirstName = "Uncle Kay",
                LastName = "Kay"
            };
            
           _customerRepository.Create(customer);
           var customerFromDB = _customerRepository.GetCustomerByUserNamePassword("uncleKay@okayhouse.com", "password");
           Assert.IsNotNull(customerFromDB);
            
        }
    }
}

using MongoDB.Bson;
using Indigo99.Data;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.BusinessServices
{
    public class AddressManagementService: IAddressManagementService
    {
        private static AddressRepository _addressRepostory;

        public AddressManagementService(AddressRepository addressRepository)
        {
            _addressRepostory = addressRepository;
        }


        public void AddNewAddress(DomainObjects.CustomerAddress customerAddress)
        {
            _addressRepostory.Create(customerAddress);
         }

        public CustomerAddress GetAddressByCustomerId(ObjectId customerId)
        {
           return _addressRepostory.GetAddressByCustomerId(customerId);
        }
    }
}

using MongoDB.Bson;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.BusinessServices
{
    public interface IAddressManagementService
    {
        void AddNewAddress(CustomerAddress customerAddress);
        CustomerAddress GetAddressByCustomerId(ObjectId customerId);
    }
}

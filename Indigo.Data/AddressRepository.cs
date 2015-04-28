using MongoDB.Bson;
using MongoDB.Driver.Builders;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.Data
{
    public class AddressRepository : GenericRepository<CustomerAddress>
    {

        public CustomerAddress GetAddressByCustomerId(ObjectId customerID)
        {
            var query = Query<CustomerAddress>.EQ(e => e.CustomerID, customerID);
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAs<CustomerAddress>(query);

            if (!gamesCursor.Any())
                return null;

            return gamesCursor.FirstOrDefault();
        }

        public override void Update(CustomerAddress entity)
        {
            throw new NotImplementedException();
        }
    }
}

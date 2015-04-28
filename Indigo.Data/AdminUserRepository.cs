using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Indigo99.DomainObjects;
using MongoDB.Bson;

namespace Indigo99.Data
{
    public class AdminUserRepository : GenericRepository<AdminUser>
    {

        public IEnumerable<AdminUser> GetAllAdminUsers(int limit, int skip)
        {
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAllAs<AdminUser>()
                .SetSortOrder(SortBy<AdminUser>.Descending(g => g.CreatedDate))
                .SetLimit(limit)
                .SetSkip(skip)
                .SetFields(Fields<AdminUser>.Include(g => g.Id, g => g.LastName, g => g.FirstName));
            return gamesCursor;
        }

        
        public AdminUser GetAdminUser(string email, string password)
        {
            var query = Query.And(Query<AdminUser>.EQ(e => e.Email, email), Query<AdminUser>.EQ( f => f.Password, password));
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAs<AdminUser>(query);

            if (!gamesCursor.Any())
                return null;

            return gamesCursor.FirstOrDefault();
        }

        public AdminUser GetAdminUserByEmail(string email)
        {
            var query = Query<AdminUser>.EQ(n => n.Email, email);
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAs<AdminUser>(query);

            if (!gamesCursor.Any())
                return null;

            return gamesCursor.FirstOrDefault();
        }

        public override void Update(AdminUser entity)
        {
            //// Not necessary for the example
        }

    }
}
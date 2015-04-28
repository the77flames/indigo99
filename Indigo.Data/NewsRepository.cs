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
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public List<News> GetAllByDate(DateTime date)
        {
            var query = Query<News>.GTE(e => e.ExpireDate, date);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<News>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }

              
    }
}

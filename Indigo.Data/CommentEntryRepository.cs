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
    public class CommentEntryRepository : GenericRepository<CommentEntry> , ICommentEntryRepository
    {
        public List<CommentEntry> GetAllByDate(DateTime date)
        {
            var query = Query<CommentEntry>.GTE(e => e.ContestDate, date);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<CommentEntry>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }
        public List<CommentEntry> GetAllByDateAndType(DateTime date, int contestType)
        {
            var query1 = Query<CommentEntry>.GTE(e => e.ContestDate, date);
            var query2 = Query<CommentEntry>.EQ(e => e.ContestType, contestType);
            var query = Query.And(query1, query2);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<CommentEntry>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }
        public List<CommentEntry> GetByContestantId(string commenterId)
        {
            var query = Query<CommentEntry>.GTE(e => e.CommenterId, commenterId);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<CommentEntry>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();

        }

    }
}

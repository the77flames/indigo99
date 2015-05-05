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
    public class ContestEntryRepository : GenericRepository<ContestEntry> , IContestEntryRepository
    {
        public List<ContestEntry> GetAllByDate(DateTime date)
        {
            var query = Query<ContestEntry>.GTE(e => e.ContestDate, date);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<ContestEntry>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }

        public List<ContestEntry> GetAllByDateAndType(DateTime date, int contestType)
        {
            var query1 = Query<ContestEntry>.GTE(e => e.ContestDate, date);
            var query2 = Query<ContestEntry>.EQ(e => e.ContestType, contestType);
            var query = Query.And(query1, query2);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<ContestEntry>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }

        public List<ContestEntry> GetByDateAndWinningStatus(DateTime date, bool winningStatus)
        {
            var query1 = Query<ContestEntry>.GTE(e => e.ContestDate, date);
            var query2 = Query<ContestEntry>.EQ(e => e.IsWinner, winningStatus);
            var query = Query.And(query1, query2);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<ContestEntry>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }

        public List<ContestEntry> GetByContestantId(string contestantId)
        {
            var query = Query<ContestEntry>.GTE(e => e.ContestantId, contestantId);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<ContestEntry>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();

        }

    }
}

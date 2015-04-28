using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.DomainObjects
{
    public interface IContestEntry : IMongoEntity
    {
        byte[] ImageBytes { get; set; }
        string ContestantId { get; set; }
        bool IsWinner { get; set; }
        int TotalVotes { get; set; }
        bool IsDisqualified { get; set; }
        DateTime ContestDate { get; set; }
    }
}

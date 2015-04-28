using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.DomainObjects
{
    public class ContestEntry : MongoEntity, IContestEntry
    {
        public byte[] ImageBytes { get; set; }
        public string ContestantId { get; set; }
        public bool IsWinner { get; set; }
        public int TotalVotes { get; set; }
        public bool IsDisqualified { get; set; }
        public ContestTypes ContestType { get; set; }
        public DateTime ContestDate { get; set; }
    }
}

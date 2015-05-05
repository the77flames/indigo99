using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.DomainObjects
{
    public class CommentEntry : MongoEntity
    {
        public string CommenterId { get; set; }
        public bool IsWinner { get; set; }
        public int TotalUpVotes { get; set; }
        public int TotalDownVotes { get; set; }
        public int ContestType { get; set; }
        public string CommentString { get; set; }
        public DateTime ContestDate { get; set; }
    }
}

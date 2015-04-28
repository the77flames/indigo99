using MongoDB.Bson;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.DomainObjects
{
    public class News : MongoEntity, INewsEntity 
    {
        public string ThumbNailImagePath { get; set; }
        public string FullSizeImagePath { get; set; }
        public string Caption { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Content { get; set; }
        public int NumberOfViews { get; set; }
      
    }
}

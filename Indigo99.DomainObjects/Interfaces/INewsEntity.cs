using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.DomainObjects
{
    public interface INewsEntity : IMongoEntity
    {      
        string ThumbNailImagePath { get; set; }       
        string FullSizeImagePath { get; set; }
        string Caption { get; set; }
        DateTime Date { get; set; }
        DateTime ExpireDate { get; set; }
        string Content { get; set; }
        int NumberOfViews { get; set; }
    }
}

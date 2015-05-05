using MongoDB.Bson;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.BusinessServices
{
    public interface ICommentEntryManagementService
    {
        void Add(CommentEntry entity);
        void Update(CommentEntry entity);
        CommentEntry GetById(string id);
        List<CommentEntry> GetAllByDateAndType(DateTime date, int contestType);
               
    }
}

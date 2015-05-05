using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.Data
{
    public interface ICommentEntryRepository : IGenericRepository<CommentEntry> 
    {
        List<CommentEntry> GetAllByDateAndType(DateTime date, int contestType);
        List<CommentEntry> GetAllByDate(DateTime date);
        List<CommentEntry> GetByContestantId(string commenterId);
    }
}

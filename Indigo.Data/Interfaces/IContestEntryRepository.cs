using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.Data
{
    public interface IContestEntryRepository : IGenericRepository<ContestEntry> 
    {
        List<ContestEntry> GetAllByDateAndType(DateTime date, int contestType);
        List<ContestEntry> GetAllByDate(DateTime date);
        List<ContestEntry> GetByDateAndWinningStatus(DateTime date, bool winningStatus);
        List<ContestEntry> GetByContestantId(string contestantId);
        List<ContestEntry> GetByWinningStatus(bool winningStatus, int count);
    }
}

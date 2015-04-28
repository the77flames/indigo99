using MongoDB.Bson;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.BusinessServices
{
    public interface IContestEntryManagementService
    {
        void Add(ContestEntry entity);
        void Update(ContestEntry entity);
        ContestEntry GetById(string id);
        List<ContestEntry> GetAllByDateAndType(DateTime date, ContestTypes contestType);
        List<ContestEntry> GetAllByDate(DateTime date);
        List<ContestEntry> GetByDateAndWinningStatus(DateTime date, bool winningStatus);
        List<ContestEntry> GetByContestantId(string contestantId);
        ContestEntry MostPopularItem(string fieldName);
       
    }
}

using MongoDB.Bson;
using Indigo99.BusinessServices;
using Indigo99.Data;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.BusinessServices
{
    public class ContestEntryManagementService : IContestEntryManagementService
    {
        private IContestEntryRepository _contestEntryRepository;

        public ContestEntryManagementService(IContestEntryRepository contestEntryRepository)
        {
            _contestEntryRepository = contestEntryRepository;
        }
        
        public void Add(ContestEntry entity)
        {
            _contestEntryRepository.Create(entity);
        }
        public List<ContestEntry> GetAll()
        {
            return _contestEntryRepository.GetAll();
        }

        
        public ContestEntry GetById(string id)
        {
            return _contestEntryRepository.GetById(id);
        }

        public IEnumerable<ContestEntry> GetAllWithPaging(int pageNumber, int pageSize)
        {
            var numberToSkip = pageNumber * pageSize;
            return _contestEntryRepository.GetAllWithPaging(numberToSkip, pageSize);
        }
            

        public ContestEntry MostPopularItem(string fieldName)
        {
            return _contestEntryRepository.GetMostPopularItemByField(fieldName);
        }
        
        public void Update(ContestEntry entity)
        {
            entity.Id = String.IsNullOrEmpty(entity.IdString) ? entity.Id : new ObjectId(entity.IdString);
            _contestEntryRepository.Update(entity);
        }


        public List<ContestEntry> GetAllByDate(DateTime date)
        {
            var result = _contestEntryRepository.GetAllByDate(date) ?? Enumerable.Empty<ContestEntry>();
            return result.OrderByDescending(n => n.ContestDate).ToList();
        }


        public List<ContestEntry> GetAllByDateAndType(DateTime date, int contestType)
        {
            var result = _contestEntryRepository.GetAllByDateAndType(date, contestType) ?? Enumerable.Empty<ContestEntry>();
            return result.OrderByDescending(n => n.ContestDate).ToList();
        }


        public List<ContestEntry> GetByDateAndWinningStatus(DateTime date, bool winningStatus)
        {
            var result = _contestEntryRepository.GetByDateAndWinningStatus(date, winningStatus) ?? Enumerable.Empty<ContestEntry>();
            return result.OrderByDescending(n => n.ContestDate).ToList();
        }

        public List<ContestEntry> GetByContestantId(string contestantId)
        {
            var result = _contestEntryRepository.GetByContestantId(contestantId) ?? Enumerable.Empty<ContestEntry>();
            return result.OrderByDescending(n => n.ContestDate).ToList();
        }
    }
}


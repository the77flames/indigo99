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
    public class CommentEntryManagementService : ICommentEntryManagementService
    {
        private ICommentEntryRepository _commentEntryRepository;

        public CommentEntryManagementService(ICommentEntryRepository commentEntryRepository)
        {
            _commentEntryRepository = commentEntryRepository;
        }

        public void Add(CommentEntry entity)
        {
            _commentEntryRepository.Create(entity);
        }
        public List<CommentEntry> GetAll()
        {
            return _commentEntryRepository.GetAll();
        }


        public CommentEntry GetById(string id)
        {
            return _commentEntryRepository.GetById(id);
        }

        public IEnumerable<CommentEntry> GetAllWithPaging(int pageNumber, int pageSize)
        {
            var numberToSkip = pageNumber * pageSize;
            return _commentEntryRepository.GetAllWithPaging(numberToSkip, pageSize);
        }
            

        public CommentEntry MostPopularItem(string fieldName)
        {
            return _commentEntryRepository.GetMostPopularItemByField(fieldName);
        }
        
        public void Update(CommentEntry entity)
        {
            entity.Id = String.IsNullOrEmpty(entity.IdString) ? entity.Id : new ObjectId(entity.IdString);
            _commentEntryRepository.Update(entity);
        }


        public List<CommentEntry> GetAllByDateAndType(DateTime date, int contestType)
        {
            var result = _commentEntryRepository.GetAllByDateAndType(date, contestType) ?? Enumerable.Empty<CommentEntry>();
            return result.OrderByDescending(n => n.ContestDate).ToList();
        }


    }
}


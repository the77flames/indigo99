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
    public class NewsManagementService : INewsManagementService
    {
        private NewsRepository _newsRepository;

        public NewsManagementService(NewsRepository NewRepository)
        {
            _newsRepository = NewRepository;
        }
        
        public void Add(News entity)
        {
            _newsRepository.Create(entity);
        }
        public List<News> GetAll()
        {
            return _newsRepository.GetAll();
        }

       
        public List<News> GetAllByDate(DateTime date)
        {
            var result = _newsRepository.GetAllByDate(date) ?? Enumerable.Empty<News>();
            return result.OrderByDescending(n => n.Date).ToList();
        }
        
        public void Update(News entity)
        {
            entity.Id = String.IsNullOrEmpty(entity.IdString) ? entity.Id : new ObjectId(entity.IdString);
            _newsRepository.Update(entity);
        }

        public News GetById(string id)
        {
           return _newsRepository.GetById(id);
        }

        public News MostPopularItem(string fieldName)
        {
            return _newsRepository.GetMostPopularItemByField(fieldName);
        }
    }
}


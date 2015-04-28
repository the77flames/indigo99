using MongoDB.Bson;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.BusinessServices
{
    public interface INewsManagementService
    {
        void Add(News entity);
        void Update(News entity);
        News GetById(string id);
        List<News> GetAllByDate(DateTime date);
        News MostPopularItem(string fieldName);       
    }
}

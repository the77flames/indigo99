using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indigo99.DomainObjects;

namespace Indigo99.Data
{
    public interface IGenericRepository<T> where T : IMongoEntity
    {
        void Create(T entity);

        void Delete(string id);

        T GetById(string id);

        void Update(T entity);

        List<T> GetAllWithPaging(int numberToSkip, int numberToReturn);

        List<T> GetByPropertyValue(string propertyName, object propertyValue, int numberToSkip, int numberToReturn);

        T GetMostPopularItemByField(string fieldName);

        List<T> GetAll();
    }
}

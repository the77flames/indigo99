using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indigo99.DomainObjects;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace Indigo99.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : IMongoEntity
    {
        protected readonly MongoDBConnectionManager<T> MongoConnectionManager;
 
        public virtual void Create(T entity)
        {
            //// Save the entity with safe mode (WriteConcern.Acknowledged)
            var result = this.MongoConnectionManager.MongoCollection.Save(
                entity, 
                new MongoInsertOptions
                {
                    WriteConcern = WriteConcern.Acknowledged
                });
 
            if (!result.Ok)
            {
                // log the errors
            }
        }
 
        public virtual void Delete(string id)
        {
            var result = this.MongoConnectionManager.MongoCollection.Remove(
                Query<T>.EQ(e => e.Id, 
                new ObjectId(id)), 
                RemoveFlags.None, 
                WriteConcern.Acknowledged);            
 
            if (!result.Ok)
            {
                //// Something went wrong
            }
        }

        protected GenericRepository()
        {
            MongoConnectionManager = new MongoDBConnectionManager<T>();
        }
 
        public virtual T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return this.MongoConnectionManager.MongoCollection.FindOne(entityQuery);
        }

        public virtual void Update(T entity)
        {
            this.MongoConnectionManager.MongoCollection.Save<T>(entity);
        }

        public List<T> GetAll()
        {
            return this.MongoConnectionManager.MongoCollection.FindAllAs<T>().ToList();
        }

        public List<T> GetAllWithPaging(int numberToSkip, int numberToReturn)
        {
            return this.MongoConnectionManager.MongoCollection.FindAllAs<T>().
                            SetSkip(numberToSkip).SetLimit(numberToReturn).ToList();
        }

        public List<T> GetByPropertyValue(string propertyName, object propertyValue, int numberToSkip, int numberToReturn)
        {
            var query = new QueryDocument(new Dictionary<string, object> { { propertyName, propertyValue } });
            return this.MongoConnectionManager.MongoCollection.FindAs<T>(query).SetSkip(numberToSkip).SetLimit(numberToReturn).ToList();
        }

        public virtual T GetMostPopularItemByField(string fieldName) 
        {
            var mostPopular = this.MongoConnectionManager.MongoCollection.FindAll().SetSortOrder(SortBy.Descending(fieldName)).SetLimit(1);
            if (mostPopular != null && mostPopular.Count() > 0)
                return mostPopular.FirstOrDefault();
            else return default(T);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indigo99.DomainObjects;
using MongoDB.Driver;
using System.Configuration;


namespace Indigo99.Data
{
    public class MongoDBConnectionManager<T> where T : IMongoEntity
    {
        public MongoCollection<T> MongoCollection { get; private set; }

        public MongoDBConnectionManager()
        {
            const string connectionString = "mongodb://localhost";
            string databaseName = ConfigurationManager.AppSettings["CurrentDatabase"].ToString();
            //// Get a thread-safe client object by using a connection string
            var mongoClient = new MongoClient(connectionString);
 
            //// Get a reference to a server object from the Mongo client object
            var mongoServer = mongoClient.GetServer();
 
            var db = mongoServer.GetDatabase(databaseName);
 
            //// Get a reference to the collection object from the Mongo database object
            //// The collection name is the type converted to lowercase + "s"
            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }


       }

    }


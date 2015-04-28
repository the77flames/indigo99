using System;
using MongoDB.Bson;

namespace Indigo99.DomainObjects
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
        string IdString { get; set; }
    }
}

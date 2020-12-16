
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Wifi.PlaylistEditor.Repositories.MongoDb.Driver
{
    public class MongoDbProvider<T> : IDataProvider<T>
    {
        private readonly IMongoDatabase _db;
        private readonly string _collectionName;

        /// <summary>
        /// Creates an instance of MongoDbProvider to get access to a mongodb
        /// </summary>
        /// <param name="connectionString">By default for a local MongoDB instance connectionString = "mongodb://localhost:27017"</param>
        /// <param name="databaseName">The name of the database to use or create.</param>
        /// <param name="collectionName">The collection name = table name</param>
        public MongoDbProvider(string connectionString, string databaseName, string collectionName)
        {
            _collectionName = collectionName;

            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(databaseName);
        }


        public void InsertDocument(T document)
        {
            var collection = _db.GetCollection<T>(_collectionName);
            collection.InsertOne(document);
        }

        public List<T> LoadAllDocuments()
        {
            var collection = _db.GetCollection<T>(_collectionName);

            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadDocumentByFilter(Expression<Func<T, bool>> filterAction)
        {
            var collection = _db.GetCollection<T>(_collectionName);            

            return collection.Find(filterAction).FirstOrDefault();
        }

        public void UpdateDocument(T document, Expression<Func<T, bool>> filterAction)
        {
            var collection = _db.GetCollection<T>(_collectionName);            
            var result = collection.ReplaceOne(filterAction, document, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteDocument(Expression<Func<T, bool>> filterAction)
        {
            var collection = _db.GetCollection<T>(_collectionName);            
            var result = collection.DeleteOne(filterAction);
        }
    }
}

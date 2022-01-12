using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsFromFrankApiTests
{
    public abstract class ControllerTestTemplate<T>
    {
        private const string databaseConnectionString = "mongodb+srv://admin:coU9Wi0UZuv2DZle@ravensu.sopbd.mongodb.net/CarsFromFrank?retryWrites=true&w=majority";
        private const string databaseName = "CarsFromFrank";
        private const string collectionName = "Cars";
        internal readonly IMongoCollection<T> collection;
        internal ControllerTestTemplate()
        {
            var mongoClient = new MongoClient(databaseConnectionString);
            var database = mongoClient.GetDatabase(databaseName);
            collection = database.GetCollection<T>(collectionName); 
        }
    }
}

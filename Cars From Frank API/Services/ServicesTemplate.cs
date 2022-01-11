using Cars_From_Frank_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cars_From_Frank_API.Services
{
    public abstract class ServicesTemplate
    {
        internal readonly IOptions<CarsFromFrankDatabaseSettings> _carsFromFrankDatabaseOptions;

        internal readonly IMongoDatabase _mongoDatabase;

        public ServicesTemplate(IOptions<CarsFromFrankDatabaseSettings> carsFromFrankDatabaseOptions)
        {
            this._carsFromFrankDatabaseOptions = carsFromFrankDatabaseOptions;

            var mongoClient = new MongoClient(carsFromFrankDatabaseOptions.Value.ConnectionString);

            this._mongoDatabase = mongoClient.GetDatabase(carsFromFrankDatabaseOptions.Value.DatabaseName);
        }
    }
}

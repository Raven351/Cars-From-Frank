using Cars_From_Frank_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cars_From_Frank_API.Services
{
    public class WarehousesService
    {
        private readonly IMongoCollection<Warehouse> _warehousesCollection;

        public WarehousesService(IOptions<CarsFromFrankDatabaseSettings> carsFromFrankDatabaseOptions)
        {
            var mongoClient = new MongoClient(carsFromFrankDatabaseOptions.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(carsFromFrankDatabaseOptions.Value.DatabaseName);

            _warehousesCollection = mongoDatabase.GetCollection<Warehouse>(carsFromFrankDatabaseOptions.Value.CollectionName);
        }

        public WarehousesService (IMongoCollection<Warehouse> warehousesCollection)
        {
            this._warehousesCollection= warehousesCollection;
        }

        public async Task<List<Warehouse>> GetAsync() =>
            await _warehousesCollection.Find(_ => true).ToListAsync();

        public async Task<Warehouse?> GetAsync(string id) =>
            await _warehousesCollection.Find(warehouse => warehouse.Id == id).FirstOrDefaultAsync();
    }
}

using Cars_From_Frank_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cars_From_Frank_API.Services
{
    /// <summary>
    /// Warehouses service. Serves data directly from MongoDB collection.
    /// </summary>
    public class WarehousesService
    {
        private readonly IMongoCollection<Warehouse> _warehousesCollection;

        /// <summary>
        /// Initializes object
        /// </summary>
        /// <param name="carsFromFrankDatabaseOptions"></param>
        public WarehousesService(IOptions<CarsFromFrankDatabaseSettings> carsFromFrankDatabaseOptions)
        {
            var mongoClient = new MongoClient(carsFromFrankDatabaseOptions.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(carsFromFrankDatabaseOptions.Value.DatabaseName);

            _warehousesCollection = mongoDatabase.GetCollection<Warehouse>(carsFromFrankDatabaseOptions.Value.CollectionName);
        }

        /// <summary>
        /// Initializes object
        /// </summary>
        /// <param name="warehousesCollection"></param>
        public WarehousesService (IMongoCollection<Warehouse> warehousesCollection)
        {
            this._warehousesCollection= warehousesCollection;
        }

        /// <summary>
        /// Gets all warehouses from MongoDB
        /// </summary>
        /// <returns>List with warehouses. If no warehouses in database, it will return empty list</returns>
        public async Task<List<Warehouse>> GetAsync() =>
            await _warehousesCollection.Find(_ => true).ToListAsync();

        /// <summary>
        /// Get warehouse with given ID if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Warehouse with given ID or null if it doesn't exist</returns>
        public async Task<Warehouse?> GetAsync(string id) =>
            await _warehousesCollection.Find(warehouse => warehouse.Id == id).FirstOrDefaultAsync();
    }
}

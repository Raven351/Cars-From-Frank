using Cars_From_Frank_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cars_From_Frank_API.Services
{
    /// <summary>
    /// Vehicles service. Serves data directly from MongoDB collection.
    /// </summary>
    public class VehiclesService : ServicesTemplate
    {
        private readonly IMongoCollection<Warehouse> _warehousesCollection;

        /// <summary>
        /// Initializes object.
        /// </summary>
        /// <param name="carsFromFrankDatabaseOptions"></param>
        public VehiclesService(IOptions<CarsFromFrankDatabaseSettings> carsFromFrankDatabaseOptions) : base(carsFromFrankDatabaseOptions)
        {
            _warehousesCollection = this._mongoDatabase.GetCollection<Warehouse>(carsFromFrankDatabaseOptions.Value.CollectionName);
        }

        /// <summary>
        /// Initializes object.
        /// </summary>
        /// <param name="collection"></param>
        public VehiclesService(IMongoCollection<Warehouse> collection) : base()
        {
            this._warehousesCollection = collection;
        }

        /// <summary>
        /// Extracts all vehicles from MongoDB
        /// </summary>
        /// <param name="order">"asc or "desc". If null it will be "asc" by default.</param>
        /// <returns></returns>
        public async Task<List<Vehicle>> GetAsync(string? order)
        {
            var warehouses = await _warehousesCollection.Find(_ => true).ToListAsync();
            List<Vehicle> vehicles = new();
            foreach (var warehouse in warehouses)
            {
                foreach (var vehicle in warehouse.CarsInWarehouse.Vehicles)
                {
                    vehicles.Add(vehicle);
                }
            }
            if (order == "desc") vehicles = vehicles.OrderBy(vehicle => vehicle.DateAdded).ToList();
            else vehicles = vehicles.OrderByDescending(vehicle => vehicle.DateAdded).ToList();

            return vehicles;
        }

        /// <summary>
        /// Gets vehicle by ID from MongoDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vehicle with given id or null if there is none</returns>
        public async Task<VehicleFullData?> GetAsyncById (string id)
        {
            var warehouses = await _warehousesCollection.Find(_ => true).ToListAsync();

            foreach(var warehouse in warehouses)
            {
                var vehicle = warehouse.CarsInWarehouse.Vehicles.Find(vehicle => vehicle.Id == Int32.Parse(id));

                if (vehicle != null)
                {
                    VehicleFullData vehicleFullData = new(vehicle)
                    {
                        GarageName = warehouse.Name,
                        Location = warehouse.WarehouseLocation,
                        CarsLocation = warehouse.CarsInWarehouse.Location
                    };
                    return vehicleFullData;
                }
            }
            return null;
        }
    }
}

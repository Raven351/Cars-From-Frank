using Cars_From_Frank_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cars_From_Frank_API.Services
{
    public class VehiclesService : ServicesTemplate
    {
        private readonly IMongoCollection<Warehouse> _warehousesCollection;

        public VehiclesService(IOptions<CarsFromFrankDatabaseSettings> carsFromFrankDatabaseOptions) : base(carsFromFrankDatabaseOptions)
        {
            _warehousesCollection = this._mongoDatabase.GetCollection<Warehouse>(carsFromFrankDatabaseOptions.Value.CollectionName);
        }

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

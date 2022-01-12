using Cars_From_Frank_API.Controllers;
using Cars_From_Frank_API.Models;
using Cars_From_Frank_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarsFromFrankApiTests
{
    public class VehiclesControllerTest : ControllerTestTemplate<Warehouse>
    {
        private readonly VehiclesController vehiclesController;

        public VehiclesControllerTest()
        {
            var vehiclesService = new VehiclesService(this.collection);
            this.vehiclesController = new VehiclesController(vehiclesService);
        }

        [Fact]
        public void GetAllByOrder_WhenCalledWithoutQueryParameters_ReturnsAllVehiclesInAscOrder()
        {
            var result = vehiclesController.GetAllByOrder();
            Assert.IsType<List<Vehicle>>(result.Result);
            AssertOrderAsc(result);
        }

        private void AssertOrderAsc(Task<List<Vehicle>> result)
        {
            List<Vehicle> vehicles = result.Result;
            vehicles.OrderByDescending(vehicle => vehicle.DateAdded);
            for (int i = 0; i < vehicles.Count; i++) Assert.Equal(vehicles[i].Id, result.Result[i].Id);
        }

        private void AssertOrderDesc(Task<List<Vehicle>> result)
        {
            List<Vehicle> vehicles = result.Result;
            vehicles.OrderBy(vehicle => vehicle.DateAdded);
            for (int i = 0; i < vehicles.Count; i++) Assert.Equal(vehicles[i].Id, result.Result[i].Id);
        }

        [Fact]
        public void GetAllByOrder_WhenCalledWithDescQueryParameter_ReturnsAllVehiclesInDescOrder()
        {
            var result = vehiclesController.GetAllByOrder("desc");
            Assert.IsType<List<Vehicle>>(result.Result);
            AssertOrderDesc(result);
        }

        [Fact]
        public void GetVehicleById_WhenCalledWithExistingId_ReturnsCorrectItem()
        {
            var result = vehiclesController.GetById("1");
            Assert.NotNull(result.Result.Value);
            if (result.Result.Value != null)
            {
                Assert.IsType<VehicleFullData>(result.Result.Value);
                Assert.IsType<int>(result.Result.Value.Id);
                Assert.Equal(1, result.Result.Value.Id);
            }
        }
    }
}

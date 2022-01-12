using Cars_From_Frank_API.Controllers;
using Cars_From_Frank_API.Models;
using Cars_From_Frank_API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CarsFromFrankApiTests
{
    public class WarehousesControllerTest : ControllerTestTemplate<Warehouse>
    {
        private readonly WarehousesController warehousesController;

        public WarehousesControllerTest()
        {
            var warehousesService = new Mock<WarehousesService>(MockBehavior.Strict, this.collection);
            warehousesController = new WarehousesController(warehousesService.Object);
        }

        [Fact]
        public void GetAllWarehouses_WhenCalled_ReturnsListOfAllWarehouses()
        {
            var result = warehousesController.Get();
            Assert.IsType<List<Warehouse>>(result.Result);
        }

        [Fact]
        public void GetWarehouseById_WhenCalled_ReturnsCorrectItem()
        {
            string id = "1";
            var result = warehousesController.Get(id);
            Assert.IsType<Warehouse>(result.Result.Value);
        }

        [Fact]
        public void GetWarehouseById_WhenCalledWithWrongId_ReturnsNull()
        {
            string id = "-1";
            var result = warehousesController.Get(id);
            Assert.Null(result.Result.Value);
        }
    }
}
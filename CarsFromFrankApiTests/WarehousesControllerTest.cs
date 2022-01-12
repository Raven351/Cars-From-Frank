using Cars_From_Frank_API.Controllers;
using Cars_From_Frank_API.Models;
using Cars_From_Frank_API.Services;
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
        public void GetAllWarehousesReturnsListOfAllWarehouses()
        {
            var result = warehousesController.Get();
            Assert.IsType<List<Warehouse>>(result.Result);
        }
    }
}
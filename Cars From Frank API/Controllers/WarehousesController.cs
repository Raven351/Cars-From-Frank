using Cars_From_Frank_API.Models;
using Cars_From_Frank_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars_From_Frank_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehousesController : ControllerBase
    {
        private readonly WarehousesService _warehousesService;

        public WarehousesController(WarehousesService warehousesService) =>
            _warehousesService = warehousesService;

        [HttpGet]
        public async Task<List<Warehouse>> Get() =>
            await _warehousesService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> Get(string id)
        {
            var warehouse = await _warehousesService.GetAsync(id);

            return warehouse is null ? NotFound() : (ActionResult<Warehouse>)warehouse;
        }
    }
}

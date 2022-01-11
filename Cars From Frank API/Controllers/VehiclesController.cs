using Cars_From_Frank_API.Models;
using Cars_From_Frank_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars_From_Frank_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehiclesService _vehiclesService;

        public VehiclesController(VehiclesService vehiclesService) =>
            this._vehiclesService = vehiclesService;

        [HttpGet]
        public async Task<List<Vehicle>> Get([FromQuery] string order = "asc") => await _vehiclesService.GetAsync(order);
    }
}

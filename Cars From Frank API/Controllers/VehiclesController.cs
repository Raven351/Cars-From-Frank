using Cars_From_Frank_API.Models;
using Cars_From_Frank_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars_From_Frank_API.Controllers
{
    /// <summary>
    /// Vehicles controller class.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehiclesService _vehiclesService;

        public VehiclesController(VehiclesService vehiclesService) =>
            this._vehiclesService = vehiclesService;

        /// <summary>
        /// GET method. Returns all vehicles in ascending order by default.
        /// </summary>
        /// <param name="order">Is either "desc" or "asc". "Desc by default"</param>
        /// <returns>List of Vehicle items inside response.</returns>
        [HttpGet]
        public async Task<List<Vehicle>> GetAllByOrder([FromQuery] string? order = "asc") => await _vehiclesService.GetAsync(order);

        /// <summary>
        /// GET method. Returns vehicle with given data. Includes additional data from parent JSON objects such as warehouse name, location etc.
        /// </summary>
        /// <param name="id">Id in string format</param>
        /// <returns>Vehicle with given ID or null if it doesn't exist</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleFullData>> GetById(string id)
        {
            var vehicle = await _vehiclesService.GetAsyncById(id);
            
            return vehicle is null ? NotFound() : (ActionResult<VehicleFullData>)vehicle;
        }
    }
}

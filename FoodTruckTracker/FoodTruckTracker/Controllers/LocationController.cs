using FoodTruckTracker.Interfaces;
using FoodTruckTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/Location
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var locations = await _locationService.GetAllAsync();
            return Ok(locations);
        }

        // POST: api/Location
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Location location)
        {
            if (ModelState.IsValid)
            {
                await _locationService.AddAsync(location);
                return CreatedAtAction(nameof(GetById), new { id = location.LocationId }, location);
            }
            return BadRequest(ModelState);
        }

        // GET: api/Location/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // PUT: api/Location/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Location location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _locationService.UpdateAsync(location);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Location/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            await _locationService.DeleteAsync(id);
            return NoContent();
        }
    }
}

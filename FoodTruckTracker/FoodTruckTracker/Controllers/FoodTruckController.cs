using FoodTruckTracker.Interfaces;
using FoodTruckTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckTracker.Controllers
{
    [ApiController] // Added this attribute for API controller
    [Route("api/[controller]")] // Set the route for the API
    public class FoodTruckController : ControllerBase
    {
        private readonly IFoodTruckService _foodTruckService;

        public FoodTruckController(IFoodTruckService foodTruckService)
        {
            _foodTruckService = foodTruckService;
        }

        // GET: api/FoodTruck
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var foodTrucks = await _foodTruckService.GetAllAsync();
            return Ok(foodTrucks); // Return JSON data
        }

        // POST: api/FoodTruck
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FoodTruck foodTruck) // Accept JSON data
        {
            if (ModelState.IsValid)
            {
                await _foodTruckService.AddAsync(foodTruck);
                return CreatedAtAction(nameof(GetById), new { id = foodTruck.FoodTruckId }, foodTruck); // Return 201 Created
            }
            return BadRequest(ModelState); // Return bad request if model state is invalid
        }

        // GET: api/FoodTruck/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var foodTruck = await _foodTruckService.GetByIdAsync(id);
            if (foodTruck == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return Ok(foodTruck); // Return found food truck as JSON
        }

        // PUT: api/FoodTruck/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] FoodTruck foodTruck)
        {
            if (id != foodTruck.FoodTruckId)
            {
                return BadRequest(); // Return 400 if IDs do not match
            }
            if (ModelState.IsValid)
            {
                await _foodTruckService.UpdateAsync(foodTruck);
                return NoContent(); // Return 204 No Content on successful update
            }
            return BadRequest(ModelState); // Return bad request if model state is invalid
        }

        // DELETE: api/FoodTruck/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodTruck = await _foodTruckService.GetByIdAsync(id);
            if (foodTruck == null)
            {
                return NotFound(); // Return 404 if not found
            }

            await _foodTruckService.DeleteAsync(id);
            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}

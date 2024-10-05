using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;
using CoreEntityFramework.Interfaces;

namespace FoodTruckTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTrucksController : ControllerBase
    {
        private readonly IFoodTruckService _foodTruckService;

        public FoodTrucksController(IFoodTruckService foodTruckService)
        {
            _foodTruckService = foodTruckService;
        }

        // GET: api/FoodTrucks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodTruck>>> GetFoodTrucks()
        {
            var foodTrucks = await _foodTruckService.GetFoodTrucks();
            return Ok(foodTrucks);
        }

        // GET: api/FoodTrucks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodTruck>> GetFoodTruck(int id)
        {
            var foodTruck = await _foodTruckService.GetFoodTruck(id);
            if (foodTruck == null)
            {
                return NotFound();
            }
            return Ok(foodTruck);
        }

        // PUT: api/FoodTrucks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodTruck(int id, FoodTruck foodTruck)
        {
            if (id != foodTruck.FoodTruckId)
            {
                return BadRequest();
            }

            if (!await _foodTruckService.FoodTruckExists(id))
            {
                return NotFound();
            }

            var updateResult = await _foodTruckService.UpdateFoodTruck(foodTruck);
            if (!updateResult)
            {
                return StatusCode(500, "Error updating food truck.");
            }

            return NoContent();
        }

        // POST: api/FoodTrucks
        [HttpPost]
        public async Task<ActionResult<FoodTruck>> PostFoodTruck(FoodTruck foodTruck)
        {
            var createdFoodTruck = await _foodTruckService.AddFoodTruck(foodTruck);
            return CreatedAtAction(nameof(GetFoodTruck), new { id = createdFoodTruck.FoodTruckId }, createdFoodTruck);
        }

        // DELETE: api/FoodTrucks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodTruck(int id)
        {
            if (!await _foodTruckService.FoodTruckExists(id))
            {
                return NotFound();
            }

            var deleteResult = await _foodTruckService.DeleteFoodTruck(id);
            if (!deleteResult)
            {
                return StatusCode(500, "Error deleting food truck.");
            }

            return NoContent();
        }
    }
}

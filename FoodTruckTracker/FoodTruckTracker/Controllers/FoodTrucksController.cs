using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodTruckTracker.Data;
using LocalFoodTruckTrackerSystem.Models;

namespace FoodTruckTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTrucksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodTrucksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodTrucks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodTruck>>> GetFoodTrucks()
        {
            return await _context.FoodTrucks.ToListAsync();
        }

        // GET: api/FoodTrucks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodTruck>> GetFoodTruck(int id)
        {
            var foodTruck = await _context.FoodTrucks.FindAsync(id);

            if (foodTruck == null)
            {
                return NotFound();
            }

            return foodTruck;
        }

        // PUT: api/FoodTrucks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodTruck(int id, FoodTruck foodTruck)
        {
            if (id != foodTruck.FoodTruckId)
            {
                return BadRequest();
            }

            _context.Entry(foodTruck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodTruckExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FoodTrucks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodTruck>> PostFoodTruck(FoodTruck foodTruck)
        {
            _context.FoodTrucks.Add(foodTruck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodTruck", new { id = foodTruck.FoodTruckId }, foodTruck);
        }

        // DELETE: api/FoodTrucks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodTruck(int id)
        {
            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            _context.FoodTrucks.Remove(foodTruck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodTruckExists(int id)
        {
            return _context.FoodTrucks.Any(e => e.FoodTruckId == id);
        }
    }
}

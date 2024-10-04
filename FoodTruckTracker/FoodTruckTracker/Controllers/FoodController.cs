using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodTruckTracker.Data;

[Route("api/[controller]")]
[ApiController]
public class FoodTruckController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FoodTruckController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/FoodTruck
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodTruck>>> GetFoodTrucks()
    {
        return await _context.FoodTrucks.ToListAsync();
    }

    // GET: api/FoodTruck/5
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

    // POST: api/FoodTruck
    [HttpPost]
    public async Task<ActionResult<FoodTruck>> PostFoodTruck(FoodTruck foodTruck)
    {
        _context.FoodTrucks.Add(foodTruck);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFoodTruck", new { id = foodTruck.Id }, foodTruck);
    }

    // PUT: api/FoodTruck/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFoodTruck(int id, FoodTruck foodTruck)
    {
        if (id != foodTruck.Id)
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

    // DELETE: api/FoodTruck/5
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
        return _context.FoodTrucks.Any(e => e.Id == id);
    }
}

using FoodTruckTracker.Interfaces;
using FoodTruckTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        // GET: api/Favorite
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var favorites = await _favoriteService.GetAllAsync();
            return Ok(favorites);
        }

        // POST: api/Favorite
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                await _favoriteService.AddAsync(favorite);
                return CreatedAtAction(nameof(GetById), new { userId = favorite.UserId, foodTruckId = favorite.FoodTruckId }, favorite);
            }
            return BadRequest(ModelState);
        }

        // GET: api/Favorite/{userId}/{foodTruckId}
        [HttpGet("{userId}/{foodTruckId}")]
        public async Task<IActionResult> GetById(string userId, int foodTruckId)
        {
            var favorite = await _favoriteService.GetByIdAsync(userId, foodTruckId);
            if (favorite == null)
            {
                return NotFound();
            }
            return Ok(favorite);
        }

        // DELETE: api/Favorite/{userId}/{foodTruckId}
        [HttpDelete("{userId}/{foodTruckId}")]
        public async Task<IActionResult> DeleteConfirmed(string userId, int foodTruckId)
        {
            var favorite = await _favoriteService.GetByIdAsync(userId, foodTruckId);
            if (favorite == null)
            {
                return NotFound();
            }

            await _favoriteService.DeleteAsync(userId, foodTruckId);
            return NoContent();
        }
    }
}

using FoodTruckTracker.Interfaces;
using FoodTruckTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        // GET: api/MenuItem
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var menuItems = await _menuItemService.GetAllAsync();
            return Ok(menuItems);
        }

        // POST: api/MenuItem
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                await _menuItemService.AddAsync(menuItem);
                return CreatedAtAction(nameof(GetById), new { id = menuItem.MenuItemId }, menuItem);
            }
            return BadRequest(ModelState);
        }

        // GET: api/MenuItem/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var menuItem = await _menuItemService.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        // PUT: api/MenuItem/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] MenuItem menuItem)
        {
            if (id != menuItem.MenuItemId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _menuItemService.UpdateAsync(menuItem);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/MenuItem/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuItem = await _menuItemService.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            await _menuItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}

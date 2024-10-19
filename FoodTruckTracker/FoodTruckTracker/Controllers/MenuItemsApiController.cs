using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodTruckTracker.Data;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodTruckTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsApiController : ControllerBase, IMenuItemsService
    {
        private readonly ApplicationDbContext _context;

        public MenuItemsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        // GET: api/MenuItems/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return menuItem;
        }

        // PUT: api/MenuItems/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItem menuItem)
        {
            if (id != menuItem.MenuItemId)
            {
                return BadRequest();
            }

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
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

        // POST: api/MenuItems
        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.MenuItemId }, menuItem);
        }

        // DELETE: api/MenuItems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.MenuItemId == id);
        }

        Task<IEnumerable<MenuItem>> IMenuItemsService.GetMenuItems()
        {
            throw new NotImplementedException();
        }

        public Task<MenuItem?> GetMenuItemById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMenuItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public Task AddMenuItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        Task<bool> IMenuItemsService.DeleteMenuItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetFoodTruckSelectList()
        {
            throw new NotImplementedException();
        }
    }
}
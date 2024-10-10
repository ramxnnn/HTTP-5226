using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Controllers.Interfaces; 
using FoodTruckTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckTracker.Services
{
    public class MenuItemService : IMenuItemsController 
    {
        private readonly ApplicationDbContext _context;

        public MenuItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuItems
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        // GET: api/MenuItems/{id}
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
            {
                return new NotFoundResult(); // Return 404 if not found
            }

            return menuItem; // Return the found menu item
        }

        // PUT: api/MenuItems/{id}
        public async Task<IActionResult> PutMenuItem(int id, MenuItem menuItem)
        {
            if (id != menuItem.MenuItemId)
            {
                return new BadRequestResult(); // Return 400 for bad request
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
                    return new NotFoundResult(); // Return 404 if item does not exist
                }
                throw; // Rethrow if there's another issue
            }

            return new NoContentResult(); // Return 204 No Content on success
        }

        // POST: api/MenuItems
        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetMenuItem), "MenuItems", new { id = menuItem.MenuItemId }, menuItem);
        }

        // DELETE: api/MenuItems/{id}
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return new NotFoundResult(); // Return 404 if item not found
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return new NoContentResult(); // Return 204 No Content on success
        }

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.MenuItemId == id);
        }
    }
}

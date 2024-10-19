using System.Collections.Generic;
using System.Linq; // Add this for SelectListItem
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // Add this for SelectListItem
using Microsoft.EntityFrameworkCore;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Controllers.Interfaces;
using FoodTruckTracker.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodTruckTracker.Services
{
    public class MenuItemService : IMenuItemsService
    {
        private readonly ApplicationDbContext _context;

        public MenuItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all MenuItems
        public async Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        // Get a single MenuItem by ID
        public async Task<MenuItem?> GetMenuItemById(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            return menuItem;
        }

        // Add a new MenuItem
        public async Task AddMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        // Update an existing MenuItem
        public async Task<bool> UpdateMenuItem(MenuItem menuItem)
        {
            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true; // Return true if update is successful
            }
            catch (DbUpdateConcurrencyException)
            {
                return false; // Return false if there's an error
            }
        }

        // Delete a MenuItem by ID
        public async Task<bool> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return false; // Return false if item not found
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
            return true; // Return true if deletion is successful
        }

        // Get a list of FoodTruck for dropdown
        public async Task<IEnumerable<SelectListItem>> GetFoodTruckSelectList()
        {
            var foodTrucks = await _context.FoodTrucks.ToListAsync();
            return foodTrucks.Select(ft => new SelectListItem
            {
                Value = ft.FoodTruckId.ToString(), // Assuming FoodTruckId is of type int
                Text = ft.Name // Assuming there's a 'Name' property in FoodTruck for display
            });
        }
    }
}

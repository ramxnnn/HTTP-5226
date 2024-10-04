using FoodTruckTracker.Data;
using FoodTruckTracker.Interfaces;
using FoodTruckTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTruckTracker.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly ApplicationDbContext _context;

        public MenuItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.Include(mi => mi.FoodTruck).ToListAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            return await _context.MenuItems.Include(mi => mi.FoodTruck).FirstOrDefaultAsync(mi => mi.MenuItemId == id);
        }

        public async Task AddAsync(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}

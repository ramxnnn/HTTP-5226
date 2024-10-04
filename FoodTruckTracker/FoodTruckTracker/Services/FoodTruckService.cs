using FoodTruckTracker.Data;
using FoodTruckTracker.Interfaces;
using FoodTruckTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTruckTracker.Services
{
    public class FoodTruckService : IFoodTruckService
    {
        private readonly ApplicationDbContext _context;

        public FoodTruckService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodTruck>> GetAllAsync()
        {
            return await _context.FoodTrucks.Include(ft => ft.Locations).ToListAsync();
        }

        public async Task<FoodTruck?> GetByIdAsync(int id)
        {
            return await _context.FoodTrucks.Include(ft => ft.Locations).FirstOrDefaultAsync(ft => ft.FoodTruckId == id);
        }

        public async Task AddAsync(FoodTruck foodTruck)
        {
            _context.FoodTrucks.Add(foodTruck);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FoodTruck foodTruck)
        {
            _context.FoodTrucks.Update(foodTruck);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            if (foodTruck != null)
            {
                _context.FoodTrucks.Remove(foodTruck);
                await _context.SaveChangesAsync();
            }
        }
    }
}

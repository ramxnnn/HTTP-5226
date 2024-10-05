using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocalFoodTruckTrackerSystem.Models;
using CoreEntityFramework.Interfaces;
using FoodTruckTracker.Data;

namespace CoreEntityFramework.Services
{
    public class FoodTruckService : IFoodTruckService
    {
        private readonly ApplicationDbContext _context;

        public FoodTruckService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all food trucks
        public async Task<IEnumerable<FoodTruck>> GetFoodTrucks()
        {
            return await _context.FoodTrucks.ToListAsync();
        }

        // Get a specific food truck by id
        public async Task<FoodTruck?> GetFoodTruck(int id)
        {
            return await _context.FoodTrucks.FindAsync(id);
        }

        // Check if a food truck exists
        public async Task<bool> FoodTruckExists(int id)
        {
            return await _context.FoodTrucks.AnyAsync(ft => ft.FoodTruckId == id);
        }

        // Update a food truck
        public async Task<bool> UpdateFoodTruck(FoodTruck foodTruck)
        {
            _context.Entry(foodTruck).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        // Add a new food truck
        public async Task<FoodTruck> AddFoodTruck(FoodTruck foodTruck)
        {
            _context.FoodTrucks.Add(foodTruck);
            await _context.SaveChangesAsync();
            return foodTruck;
        }

        // Delete a food truck
        public async Task<bool> DeleteFoodTruck(int id)
        {
            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            if (foodTruck == null)
            {
                return false;
            }

            _context.FoodTrucks.Remove(foodTruck);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

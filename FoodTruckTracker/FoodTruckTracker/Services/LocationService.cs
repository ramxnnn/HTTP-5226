using FoodTruckTracker.Data;
using FoodTruckTracker.Interfaces;
using FoodTruckTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckTracker.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.Locations.Include(l => l.FoodTruck).ToListAsync();
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            return await _context.Locations.Include(l => l.FoodTruck).FirstOrDefaultAsync(l => l.LocationId == id);
        }

        public async Task AddAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
    }
}

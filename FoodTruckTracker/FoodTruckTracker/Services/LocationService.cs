using Microsoft.EntityFrameworkCore;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Services.Interfaces;
using FoodTruckTracker.Data;

namespace FoodTruckTracker.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all locations
        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        // Get a specific location by id
        public async Task<Location?> GetLocation(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        // Check if a location exists
        public async Task<bool> LocationExists(int id)
        {
            return await _context.Locations.AnyAsync(e => e.LocationId == id);
        }

        // Update a location
        public async Task<bool> UpdateLocation(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        // Add a new location
        public async Task<Location> AddLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        // Delete a location
        public async Task<bool> DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return false;
            }

            _context.Locations.Remove(location);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Location?> GetLocationById(int locationId)
        {
            return await _context.Locations.FindAsync(locationId);
        }
    }
}

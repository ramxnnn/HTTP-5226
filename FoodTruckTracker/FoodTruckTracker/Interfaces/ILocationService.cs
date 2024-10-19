using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;

namespace FoodTruckTracker.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location?> GetLocation(int id);
        Task<Location?> GetLocationById(int locationId);
        Task<bool> UpdateLocation(Location location);
        Task<Location> AddLocation(Location location);
        Task<bool> DeleteLocation(int id);
        Task<bool> LocationExists(int id);
    }
}

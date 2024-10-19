using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodTruckTracker.Controllers.Interfaces
{
    public interface IMenuItemsService
    {
        Task<IEnumerable<MenuItem>> GetMenuItems(); // No change needed
        Task<MenuItem?> GetMenuItemById(int id); // No change needed
        Task<bool> UpdateMenuItem(MenuItem menuItem); // No change needed
        Task AddMenuItem(MenuItem menuItem); // No change needed
        Task<bool> DeleteMenuItem(int id); // No change needed
        Task<IEnumerable<SelectListItem>> GetFoodTruckSelectList(); // Update return type
    }
}

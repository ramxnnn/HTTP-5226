using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodTruckTracker.Controllers.Interfaces
{
    public interface IMenuItemsService
    {
        Task<IEnumerable<MenuItem>> GetMenuItems(); 
        Task<MenuItem?> GetMenuItemById(int id); 
        Task<bool> UpdateMenuItem(MenuItem menuItem); 
        Task AddMenuItem(MenuItem menuItem); 
        Task<bool> DeleteMenuItem(int id); 
        Task<IEnumerable<SelectListItem>> GetFoodTruckSelectList(); 
    }
}

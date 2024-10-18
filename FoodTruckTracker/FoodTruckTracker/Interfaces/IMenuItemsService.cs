using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;

namespace FoodTruckTracker.Controllers.Interfaces
{
    public interface IMenuItemsService
    {
        Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems();
        Task<ActionResult<MenuItem>> GetMenuItem(int id);
        Task<IActionResult> PutMenuItem(int id, MenuItem menuItem);
        Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuItem);
        Task<IActionResult> DeleteMenuItem(int id);
    }
}
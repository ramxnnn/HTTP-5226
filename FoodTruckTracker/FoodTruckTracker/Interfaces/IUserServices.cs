using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;

namespace FoodTruckTracker.Controllers.Interfaces
{
    public interface IUserServices
    {
        Task<ActionResult<IEnumerable<User>>> GetUser();
        Task<ActionResult<User>> GetUser(int id);
        Task<IActionResult> PutUser(int id, User user);
        Task<ActionResult<User>> PostUser(User user);
        Task<IActionResult> DeleteUser(int id);
    }
}
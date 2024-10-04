using FoodTruckTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTruckTracker.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem?> GetByIdAsync(int id);
        Task AddAsync(MenuItem menuItem);
        Task UpdateAsync(MenuItem menuItem);
        Task DeleteAsync(int id);
    }
}

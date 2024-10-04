using FoodTruckTracker.Models;

namespace FoodTruckTracker.Interfaces
{
    public interface IFoodTruckService
    {
        Task<IEnumerable<FoodTruck>> GetAllAsync();
        Task<FoodTruck?> GetByIdAsync(int id);
        Task AddAsync(FoodTruck foodTruck);
        Task UpdateAsync(FoodTruck foodTruck);
        Task DeleteAsync(int id);
    }
}

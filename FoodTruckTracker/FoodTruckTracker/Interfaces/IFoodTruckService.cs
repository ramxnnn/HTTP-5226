using System.Collections.Generic;
using System.Threading.Tasks;
using LocalFoodTruckTrackerSystem.Models;

namespace CoreEntityFramework.Interfaces
{
    public interface IFoodTruckService
    {
        Task<FoodTruck?> GetFoodTruckById(int id);
        Task<IEnumerable<FoodTruck>> GetFoodTrucks();
        Task<FoodTruck?> GetFoodTruck(int id);
        Task<bool> FoodTruckExists(int id);
        Task<bool> UpdateFoodTruck(FoodTruck foodTruck);
        Task<FoodTruck> AddFoodTruck(FoodTruck foodTruck);
        Task<bool> DeleteFoodTruck(int id);
    }
}

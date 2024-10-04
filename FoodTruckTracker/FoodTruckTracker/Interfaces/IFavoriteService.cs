using FoodTruckTracker.Models;

namespace FoodTruckTracker.Interfaces
{
    public interface IFavoriteService
    {
        Task<IEnumerable<Favorite>> GetAllAsync();
        Task<Favorite?> GetByIdAsync(string userId, int foodTruckId);
        Task AddAsync(Favorite favorite);
        Task DeleteAsync(string userId, int foodTruckId);
    }

}

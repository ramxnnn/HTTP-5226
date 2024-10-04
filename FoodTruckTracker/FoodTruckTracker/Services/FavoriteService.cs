using FoodTruckTracker.Data;
using FoodTruckTracker.Interfaces;
using FoodTruckTracker.Models;
using Microsoft.EntityFrameworkCore; // Make sure this is included


public class FavoriteService : IFavoriteService
{
    private readonly ApplicationDbContext _context;

    public FavoriteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Favorite>> GetAllAsync()
    {
        return await _context.Favorites.Include(f => f.FoodTruck).ToListAsync();
    }

    public async Task<Favorite?> GetByIdAsync(string userId, int foodTruckId)
    {
        return await _context.Favorites
            .FirstOrDefaultAsync(f => f.UserId == userId && f.FoodTruckId == foodTruckId);
    }

    public async Task AddAsync(Favorite favorite)
    {
        _context.Favorites.Add(favorite);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string userId, int foodTruckId)
    {
        var favorite = await GetByIdAsync(userId, foodTruckId);
        if (favorite != null)
        {
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
        }
    }
}

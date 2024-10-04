using Microsoft.AspNetCore.Identity;

namespace FoodTruckTracker.Models
{
    public class User : IdentityUser
    {
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}

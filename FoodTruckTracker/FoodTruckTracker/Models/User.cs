using System.ComponentModel.DataAnnotations;

namespace LocalFoodTruckTrackerSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public required string Username { get; set; }

        public required string Email { get; set; }

        // A user can favorite multiple food trucks
        public ICollection<FoodTruck>? FavoriteFoodTrucks { get; set; }
    }

    public class UserDto
    {
        public int UserId { get; set; }

        public required string Username { get; set; }

        public required string Email { get; set; }
    }
}

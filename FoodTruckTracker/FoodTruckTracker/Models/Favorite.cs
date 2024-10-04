using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckTracker.Models
{
    public class Favorite
    {
        [Key] // Marks this property as the primary key
        public int FavoriteId { get; set; }

        public required string UserId { get; set; } // Assuming this is the ID of the User
        public required IdentityUser User { get; set; } = new IdentityUser(); // Initialize with a new instance

        public required int FoodTruckId { get; set; } // Foreign key to FoodTruck
        public required FoodTruck FoodTruck { get; set; } = new FoodTruck // Initialize FoodTruck with default values
        {
            Name = "Default Food Truck",
            Description = "Default Description",
            CuisineType = "Default Cuisine",
            OwnerName = "Default Owner",
            ContactInfo = "Default Contact Info",
            LogoUrl = "Default Logo URL"
        };
    }
}

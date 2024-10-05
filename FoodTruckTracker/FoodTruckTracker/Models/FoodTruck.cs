using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalFoodTruckTrackerSystem.Models
{
    public class FoodTruck
    {
        [Key]
        public int FoodTruckId { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Contact { get; set; }  // Previously the LogoUrl

        // A food truck can be at one location
        [ForeignKey("Location")]
        public int LocationId { get; set; }  // Foreign key to Location

        public Location? Location { get; set; }  // Navigation property for the Location

        // A food truck can have many menu items
        public ICollection<MenuItem>? MenuItems { get; set; } = new List<MenuItem>();

        // A food truck can be favorited by multiple users
        public ICollection<User>? FavoritedByUsers { get; set; } = new List<User>();
    }

    public class FoodTruckDto
    {
        public int FoodTruckId { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Contact { get; set; }

        public int LocationId { get; set; }  // Include LocationId in DTO if needed
    }

}

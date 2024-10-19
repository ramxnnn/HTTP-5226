using System.ComponentModel.DataAnnotations;

namespace LocalFoodTruckTrackerSystem.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        [Required] // Ensure this field is required
        public required string Name { get; set; }

        [Required] // Ensure this field is required
        public required string Description { get; set; }

        [Required] // Ensure this field is required
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public required decimal Price { get; set; }

        // Each menu item belongs to a food truck
        public int FoodTruckId { get; set; }

        public FoodTruck? FoodTruck { get; set; }
    }

    public class MenuItemDto
    {
        public int MenuItemId { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required decimal Price { get; set; }

        public int FoodTruckId { get; set; }
    }
}

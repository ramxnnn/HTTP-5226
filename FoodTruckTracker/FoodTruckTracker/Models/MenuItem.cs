using System.ComponentModel.DataAnnotations;

namespace LocalFoodTruckTrackerSystem.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

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

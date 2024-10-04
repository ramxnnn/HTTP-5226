using System.ComponentModel.DataAnnotations;

namespace FoodTruckTracker.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; } // Assuming you have a price property

        public int FoodTruckId { get; set; }
        public required FoodTruck FoodTruck { get; set; }
    }
}

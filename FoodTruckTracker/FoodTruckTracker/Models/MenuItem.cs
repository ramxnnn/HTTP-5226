namespace FoodTruckTracker.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string PhotoUrl { get; set; }
        public int FoodTruckId { get; set; }

        // Initialize FoodTruck with required fields
        public required FoodTruck FoodTruck { get; set; } = new()
        {
            Name = "Default Food Truck",       // Provide a default value for required properties
            Description = "Default Description",
            CuisineType = "Default Cuisine",
            OwnerName = "Default Owner",
            ContactInfo = "Default Contact Info",
            LogoUrl = "Default Logo URL"
        };
    }
}
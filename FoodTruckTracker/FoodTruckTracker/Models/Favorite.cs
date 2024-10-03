namespace FoodTruckTracker.Models
{
    public class Favorite
    {
        public int UserId { get; set; }

        // Initialize User with default values for required properties
        public required User User { get; set; } = new()
        {
            UserName = "Default User", // Provide default values for required properties
            Email = "default@example.com"
        };

        public int FoodTruckId { get; set; }

        // Initialize FoodTruck with default values for required properties
        public required FoodTruck FoodTruck { get; set; } = new()
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
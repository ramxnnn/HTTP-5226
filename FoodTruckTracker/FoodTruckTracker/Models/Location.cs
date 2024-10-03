namespace FoodTruckTracker.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public required string Address { get; set; } // The required modifier is correctly applied.
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int FoodTruckId { get; set; }

        // Initialize FoodTruck with default values for required properties
        public required FoodTruck FoodTruck { get; set; } = new()
        {
            Name = "Default Food Truck",          // Provide default values for required properties
            Description = "Default Description",
            CuisineType = "Default Cuisine",
            OwnerName = "Default Owner",
            ContactInfo = "Default Contact Info",
            LogoUrl = "Default Logo URL"
        };
    }
}
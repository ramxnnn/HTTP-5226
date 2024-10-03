namespace FoodTruckTracker.Models
{
    public class FoodTruck
    {
        public int FoodTruckId { get; set; }
        public required string Name { get; set; } // Add required modifier
        public required string Description { get; set; } // Add required modifier
        public required string CuisineType { get; set; } // Add required modifier
        public required string OwnerName { get; set; } // Add required modifier
        public required string ContactInfo { get; set; } // Add required modifier
        public required string LogoUrl { get; set; } // Add required modifier
        public ICollection<Location> Locations { get; set; } = new List<Location>();
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
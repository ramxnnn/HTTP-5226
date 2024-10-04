using System.Collections.Generic;

namespace FoodTruckTracker.Models
{
    public class FoodTruck
    {
        public int FoodTruckId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string CuisineType { get; set; }
        public required string OwnerName { get; set; }
        public required string ContactInfo { get; set; }
        public required string LogoUrl { get; set; }

        public ICollection<Location> Locations { get; set; } = new List<Location>();
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}

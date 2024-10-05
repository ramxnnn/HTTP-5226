using System.ComponentModel.DataAnnotations;

namespace LocalFoodTruckTrackerSystem.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public required string Address { get; set; }

        public required string City { get; set; }

        public required string State { get; set; }

        // Each location can host multiple food trucks
        public ICollection<FoodTruck>? FoodTrucks { get; set; } = new List<FoodTruck>();
    }

    public class LocationDto
    {
        public int LocationId { get; set; }

        public required string Address { get; set; }

        public required string City { get; set; }

        public required string State { get; set; }
    }
}

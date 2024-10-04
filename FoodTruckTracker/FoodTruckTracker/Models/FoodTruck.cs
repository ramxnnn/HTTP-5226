using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodTruckTracker.Models
{
    public class FoodTruck
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!; // Use null-forgiving operator

        [Required]
        public string Description { get; set; } = null!; // Use null-forgiving operator

        [Required]
        public string Contact { get; set; } = null!; // Use null-forgiving operator

        [JsonIgnore]
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>(); // Initialize to an empty list
    }
}

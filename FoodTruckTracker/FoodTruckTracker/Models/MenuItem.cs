using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTruckTracker.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        // Foreign key to FoodTruck
        public int FoodTruckId { get; set; }

        // Navigation property
        [ForeignKey("FoodTruckId")]
        public FoodTruck FoodTruck { get; set; }
    }
}

namespace FoodTruckTracker.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public required string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int FoodTruckId { get; set; }

        public required FoodTruck FoodTruck { get; set; }
    }
}

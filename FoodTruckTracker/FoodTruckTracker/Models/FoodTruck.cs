using System.ComponentModel.DataAnnotations;

public class FoodTruck
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public string Description { get; set; }

    // Additional properties
    public string Cuisine { get; set; }
    public string Contact { get; set; }
}

using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    // Additional properties for your user can be added here
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePictureUrl { get; set; }
}

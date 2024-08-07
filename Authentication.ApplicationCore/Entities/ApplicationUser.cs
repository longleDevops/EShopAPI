using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Entities;

public class ApplicationUser: IdentityUser<Guid>
{
    public ApplicationUser()
    {
            
    }
    
    public ApplicationUser(string firstName, string lastName, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}
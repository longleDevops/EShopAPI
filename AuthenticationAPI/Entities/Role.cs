using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Entities;

public class Role: IdentityRole<Guid>
{
    public ICollection<UserRole> UserRoles { get; set; }
}
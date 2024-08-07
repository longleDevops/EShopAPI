using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Entities;

public class UserRole: IdentityUserRole<Guid>
{
    public ApplicationUser User { get; set; }
    public Role Role { get; set; }
}
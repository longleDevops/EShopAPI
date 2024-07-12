using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Entities;

public class UserRole: IdentityUserRole<Guid>
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    
    public ApplicationUser User { get; set; }
    public Role Role { get; set; }
}
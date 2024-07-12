using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Models;

public class LoginModel
{
    [Required]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
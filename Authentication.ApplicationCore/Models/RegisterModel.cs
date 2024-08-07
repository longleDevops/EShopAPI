using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Models;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
    [Required]
    [StringLength(50)] 
    public string FirstName { get; set; }
    [Required]
    [StringLength(50)] 
    public string LastName { get; set; }
    [Required]
    public DateTime DateOfBirth { get;set; }
    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string Role { get; set; }
}
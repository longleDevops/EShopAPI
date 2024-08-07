using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Authentication.API.Entities
{
    public class CustomerRegisterModel
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
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        
        [JsonIgnore]
        public string Role { get; set; } = "Customer";
    }
}
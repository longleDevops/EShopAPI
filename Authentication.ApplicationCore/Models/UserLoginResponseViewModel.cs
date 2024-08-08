using Authentication.API.Entities;

namespace Authentication.Models
{
    public class UserLoginResponseViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string role { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
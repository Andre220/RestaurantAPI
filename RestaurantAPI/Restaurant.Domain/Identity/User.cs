using Microsoft.AspNetCore.Identity;

namespace Restaurant.Domain.Identity
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}

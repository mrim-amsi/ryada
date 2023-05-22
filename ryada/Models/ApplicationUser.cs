using Microsoft.AspNetCore.Identity;

namespace ryada
{
    public class ApplicationUser : IdentityUser
    {
        public string PhoneNumber { get; set; } = null!;
    }
}
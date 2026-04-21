using Microsoft.AspNetCore.Identity;

namespace AMBUS.Infrastructure.Identity.Models
{
    public class AppUser:IdentityUser
    {
        public string Address { get; set; } = null!;
    }
}

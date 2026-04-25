using Microsoft.AspNetCore.Identity;

namespace AMBUS.Domain.Models
{
    public class AppUser:IdentityUser
    {
        public string NationalNumber { get; set; } = null!;
        public string DrivingLicense { get; set; } = null!;
        public DateTime LicenseExpire { get; set; }

        public string FullName { get; set; } = null!;
        public string? Address { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Application.Dtos.Request
{
    public class DriverRegisterRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        public string PhoneNumber { get; set; }
        public string NationalNumber { get; set; } = null!;
        public string DrivingLicense { get; set; } = null!;
        public DateTime LicenseExpire { get; set; }
    }
}

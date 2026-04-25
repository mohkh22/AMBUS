using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Application.Dtos.Request
{
    public class RegisterRequest
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        public string PhoneNumber { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Application.Dtos.Response
{
    public class AuthResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}

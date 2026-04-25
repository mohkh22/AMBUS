
using AMBUS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AMBUS.Application.Abstraction
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(AppUser user);
    }
}

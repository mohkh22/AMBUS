using AMBUS.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AMBUS.Application.CQRS.Commands
{
    public record RegisterCommand(
        string FName,
        string LName,
        string Email,
        string Password,
        string Address
    ) : IRequest<AuthResponse>;

}

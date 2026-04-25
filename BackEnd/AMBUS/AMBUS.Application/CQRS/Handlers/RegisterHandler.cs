using AMBUS.Application.Abstraction;
using AMBUS.Application.CQRS.Commands;
using AMBUS.Application.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Application.CQRS.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly IAuth _authService;
        public RegisterHandler(IAuth authService) => _authService = authService;

        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authService.Register(new Dtos.Request.RegisterRequest
            {
                Email = request.Email,
                Password = request.Password,
                FName = request.FName,
                LName = request.LName,
                Address = request.Address
            });
        }
    }
}

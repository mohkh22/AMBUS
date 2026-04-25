using AMBUS.Application.Dtos.Request;
using AMBUS.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Application.Abstraction
{
    public interface IAuth
    {
        Task<AuthResponse> Login(LoginRequest request);
        Task<AuthResponse> Register(RegisterRequest request);
        Task<bool> ConfirmEmail(string userId, string token);
        Task ForgetPassword(string email);
        Task<bool> ResetPassword(ResetPasswordRequest request);

        Task<bool> RegisterDriver (DriverRegisterRequest request);
        Task<UserProfileResponse> GetProfile(string userId);
    }
}

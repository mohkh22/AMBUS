using AMBUS.Application.Abstraction;
using AMBUS.Application.Dtos.Request;
using AMBUS.Application.Dtos.Response;
using AMBUS.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Infrastructure.Implementations
{
    public class Auth : IAuth
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public Auth(UserManager<AppUser> userManager, IJwtTokenGenerator jwtTokenGenerator, IEmailService emailService, IMapper mapper)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<bool> ConfirmEmail(string userId, string token)
        {
            var user =await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                // سطر احتياطي لضمان التفعيل في قاعدة البيانات فوراً
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return true;
            }

            return false;
        }

        public async Task ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return; 

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            await _emailService.SendEmail(email, "Reset Your Password - AMBUS",
                    $"Your password reset token is: <b>{token}</b>");
        }

        public async Task<AuthResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("Invalid email or password.");
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new Exception("Please confirm your email before logging in.");
            }

            var token = await _jwtTokenGenerator.GenerateToken(user);

            var response = _mapper.Map<AuthResponse>(user);

            response.Token = token;

            return response;
        }
        public async Task<AuthResponse> Register(RegisterRequest request)
        {
            //new user
            var user = _mapper.Map<AppUser>(request);

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User registration failed: {errors}");
            }

            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebUtility.UrlEncode(confirmationToken);
            // هنا هنضيف الفرونت يبو خالد بدل اللينك
            var confirmationLink = $"https://localhost:44330/api/Auth/ConfirmEmail?userId={user.Id}&token={encodedToken}";
            try
            {
                await _emailService.SendEmail(user.Email, "Confirm Your Email - AMBUS",
                    $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");
               
            }
            catch (Exception ex)
            {
                await _userManager.DeleteAsync(user);
                throw new Exception("Failed to send confirmation email. Please try again later.", ex);
            }
            
            //Roles
            await _userManager.AddToRoleAsync(user,"User");
           
           
           var response = _mapper.Map<AuthResponse>(user);
            response.Token = await _jwtTokenGenerator.GenerateToken(user);
            return response;
        }

        public async Task<bool> RegisterDriver(DriverRegisterRequest request)
        {
          var user = _mapper.Map<AppUser>(request);
            user.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Driver registration failed: {errors}");
            }
           await _userManager.AddToRoleAsync(user, "Driver");
            return true;
        }

        public async Task<bool> ResetPassword(ResetPasswordRequest request)
        {
            var user =await _userManager.FindByEmailAsync(request.Email);

            if (user == null) return false; 

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            return result.Succeeded;
        }

        public async Task<UserProfileResponse> GetProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            { throw new Exception("User not found"); }

            return _mapper.Map<UserProfileResponse>(user);
        }
    }
}

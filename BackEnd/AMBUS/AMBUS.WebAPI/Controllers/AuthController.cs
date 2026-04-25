using AMBUS.Application.Abstraction;
using AMBUS.Application.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AMBUS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authService;

        public AuthController(IAuth authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.Register(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.Login(request);
            return Ok(result);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
                return BadRequest("Invalid confirmation link.");

            var result = await _authService.ConfirmEmail(userId, token);

            if (result)
                return Ok("Email confirmed successfully! You can now login.");

            return BadRequest("Email confirmation failed.");
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([EmailAddress] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Email is required.");

            await _authService.ForgetPassword(email);
            return Ok("If the email exists, a reset token has been sent.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ResetPassword(request);

            if (result)
                return Ok("Password has been reset successfully.");

            return BadRequest("Failed to reset password.");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("register-driver")]
        public async Task<IActionResult> RegisterDriver([FromBody] DriverRegisterRequest request)
        {
            var result = await _authService.RegisterDriver(request);
            return result ? Ok("Driver registered successfully") : BadRequest("Failed to register driver");
        }



        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // بجيب الـ ID من التوكن
            var profile = await _authService.GetProfile(userId);
            return Ok(profile);
        }
    }
}

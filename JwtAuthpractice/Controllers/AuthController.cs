using JwtAuthpractice.Entity;
using JwtAuthpractice.Models;
using JwtAuthpractice.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthpractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("userName Already Exist");
            }

            return Ok(user);

        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDTO request)
        {
            //if (user.UserName != request.UserName)
            //{
            //    return BadRequest("User Not Found");
            //}
            //if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            //{
            //    return BadRequest("Wrong Password");
            //}
            var result = await authService.LoginAsync(request);
            if (result is null)
            {
                return BadRequest("Invalid user name or password");
            }
            return Ok(result);

        }
        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokenAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
            {
                return Unauthorized("Invalid Request token");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthentictedOnlyEndpoint()
        {
            return Ok("You are Authenticated!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are Admin!");
        }


    }
}

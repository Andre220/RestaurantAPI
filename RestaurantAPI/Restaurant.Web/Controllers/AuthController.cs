using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Domain.Identity;
using Restaurant.Shared.DTOs.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurant.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            var user = new User 
            { 
                UserName = dto.Email, 
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded) 
                return BadRequest(result.Errors);//TODO: Replace for APIResult

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var currentUser = await _userManager.FindByEmailAsync(dto.Email);

            if (currentUser == null || !await _userManager.CheckPasswordAsync(currentUser, dto.Password))
                return Unauthorized();

            var authClaims = new[]
            {
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, currentUser.Email),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = GenerateJwtToken(currentUser);

            //TODO: Criar o attribute que appenda ao cookie o JWT e que lê do JWT quando uma action é chamada.
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,  // Previne CSRF
                Expires = DateTime.UtcNow.AddHours(1) // Duração do cookie
            };

            Response.Cookies.Append("JwtToken", token, cookieOptions);

            return Ok(new {message  = "Login bem-sucedido!", token = token});
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                //TODO: Add the real claims
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Identity;
using RestaurantWeb.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurant.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public BaseController()
        //{
        //}

        protected User GetAuthenticatedUser()
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Token JWT não encontrado.");
            }

            var user = ValidateJwtToken(token);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Token JWT inválido.");
            }

            return user;
        }

        private User ValidateJwtToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                var claims = jsonToken?.Claims;

                if (claims != null)
                {
                    var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    return userId == null ? null : new User { Id = Guid.Parse(userId) };
                }
            }
            catch (Exception ex)
            {
                Log.LogError($"Error on validating JWT: {ex.Message}");
            }

            return null;
        }
    }
}

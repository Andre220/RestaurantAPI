using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurant.Domain.Identity;
using RestaurantWeb.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurant.Web.Filters
{
    //TODO: Erase
    public class JwtAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly IConfiguration _configuration;

        public JwtAuthorizeAttribute(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult(new { message = "Token JWT não encontrado." });
                return;
            }

            var user = ValidateJwtToken(token);
            if (user == null)
            {
                context.Result = new UnauthorizedObjectResult(new { message = "Token JWT inválido." });
                return;
            }

            // Armazena o usuário no contexto, caso seja necessário nas actions
            context.HttpContext.Items["User"] = user;

            base.OnActionExecuting(context);
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
                    return new User { Id = Guid.Parse(userId)};
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

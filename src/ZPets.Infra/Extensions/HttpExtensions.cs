using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ZPets.Infra.Extensions
{
    public static class HttpExtensions
    {
        public const string AccessToken = "access_token";

        public async static Task<string> GetAccessToken(this HttpContext httpContext)
        {
            return (await httpContext.GetTokenAsync(AccessToken))!;
        }

        public static string GetUserId(this HttpContext context)
        {
            var userId = context.User.FindFirst(ClaimTypes.Sid)?.Value;

            return userId!;
        }
    }
}

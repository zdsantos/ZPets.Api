using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZPets.Infra.Models;

namespace ZPets.Infra.Helpers
{
    public class IdentityHelper
    {
        private readonly JwtSettings _settings;

        public IdentityHelper(AppSettings settings)
        {
            _settings = settings.JwtSettings;
        }

        public string GenerateToken(string userId, string userEmail)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_settings.Key);

            SigningCredentials credentials = new (new SymmetricSecurityKey(key),
                                                  SecurityAlgorithms.HmacSha256Signature);

            var descriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Subject = GetClaimsIdentity(userId, userEmail),
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                Expires = DateTime.UtcNow.AddDays(1),
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }

        private static ClaimsIdentity GetClaimsIdentity(string userId, string userEmail)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, userId));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, userEmail));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, userEmail));

            return claimsIdentity;
        }

        public string Encrypt(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(String.Concat(_settings.Key, password));
            data = System.Security.Cryptography.SHA256.HashData(data);
            var hash = Convert.ToBase64String(data);

            return hash;
        }

        public bool ComparePassword(string password, string hash)
        {
            var hashToCompare = Encrypt(password);
            return hashToCompare.Equals(hash);
        }
    }
}

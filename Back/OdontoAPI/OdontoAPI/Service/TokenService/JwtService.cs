using Microsoft.IdentityModel.Tokens;
using OdontoAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OdontoAPI.Service.TokenService
{
    public class JwtService
    {
        public string Create(UserModel user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2)
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(UserModel user)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim("Id", user.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            ci.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
            ci.AddClaim(new Claim("image", user.Image));

            foreach (var role in user.Roles)
            {
                ci.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return ci;
        }
    }
}

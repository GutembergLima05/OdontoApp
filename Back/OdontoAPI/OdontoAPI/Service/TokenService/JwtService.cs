using Microsoft.IdentityModel.Tokens;
using OdontoAPI.Models;
using System.IdentityModel.Tokens.Jwt;
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
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2)
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}

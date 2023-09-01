using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OdontoAPI.Models;
using OdontoAPI.Service.TokenService;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OdontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : Controller
    {
        private readonly JwtService _jwtService;

        public JwtController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost]
        public string Create(UserModel user)
        {
            return _jwtService.Create(user);
        }
    }
}

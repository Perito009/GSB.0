using GSB._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GSB2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly GSB_2024Context _context;
        private IConfiguration _config;

        public TokenController(IConfiguration config, GSB_2024Context context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest loginRequest)
        {
            // Votre logique de processus de connexion
            // Si le nom d'utilisateur et le mot de passe sont corrects, générez le jeton

            User? user = _context.Users
                .Where(U => U.LoginUser.Equals(loginRequest.Login_User) && U.PassewordUser.Equals(loginRequest.Passeword_User))
                .FirstOrDefault();

            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);
            }

            return BadRequest();
        }
    }
}

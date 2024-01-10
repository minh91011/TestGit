using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyWebAPIApp.Data;
using MyWebAPIApp.Models;
using MyWebAPIApp.Models.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private MyDBContext _context;
        private readonly Key key;

        public AccountController(MyDBContext context, IOptionsMonitor<Key> optionsMonitor) { 
            _context = context;
            key = optionsMonitor.CurrentValue;
        }

        [HttpPost("login")]
        public IActionResult Validate(LoginVM loginVM)
        {
            var user = _context.accounts.SingleOrDefault(a => a.usename == loginVM.usename && a.password == loginVM.password);
            if(user == null)
            {
                return Ok(new APIResponse
                {
                    Success = false,
                    Message = "Ivalid username or password"
                });
            }
            //send token

            return Ok(new APIResponse
            {
                Success = true,
                Message = "Authenticate success!",
                Data = GenerateToken(user)
            });
        }

        private string GenerateToken(Account account)
        {
            var jwtTokenHandle = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(key.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, account.fullName),
                    new Claim(ClaimTypes.Email, account.email),
                    new Claim("username", account.usename),
                    new Claim("id", account.id.ToString()),

                    new Claim("TokenID", Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature),
            };

            var token = jwtTokenHandle.CreateToken(tokenDescription);

            return jwtTokenHandle.WriteToken(token) ;
        }
    }
}

using backend.Helpers;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApp;
using WebApp.Models;

namespace backend.Controllers
{
    //del later
    public class ResultOut
    {
        public string? UserName { get; set; }
        public Guid Id { get; set; }
    }
    //del later


    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly UserDbContext _context;
        public LoginController(UserDbContext context)
        {
            _context = context;
        }

        public static UserAuthent user = new();

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(UserAuthent request)
        {
            //TODO password hash BCript?
            var user = await _context.UsersAuthent.FindAsync(request.UserName);

            if (user == null)
            {
                return NotFound("User no found!");
            }
            if (user.Password != request.Password)
            {
                return NotFound("Wrong password!");
            }
            /*var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, User.UserName) };
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(AuthenticationPar.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);*/


            //*del later
            ResultOut result = new();
            result.UserName = user.UserName;
            result.Id = user.Id;
            //*del later

            return Ok(result);
        }
    }
}

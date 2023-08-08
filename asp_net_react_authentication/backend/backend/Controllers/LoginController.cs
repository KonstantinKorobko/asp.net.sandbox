using backend.Helpers;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp;
using WebApp.Models;

namespace backend.Controllers
{
    //del later
   /* public class ResultOut
    {
        public string? UserName { get; set; }
        public Guid Id { get; set; }
    }*/
    //del later


    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly UserDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(UserDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(UserAuthent request)
        {
            //TODO password hash BCript?
            UserAuthent user = await _context.UsersAuthent.FindAsync(request.UserName);

            if (user == null)
            {
                return NotFound("User no found!");
            }
            if (user.Password != request.Password)
            {
                return NotFound("Wrong password!");
            }

            //*del later
            /*ResultOut result = new();
            result.UserName = user.UserName;
            result.Id = user.Id
            return Ok(result);;*/
            //*del later

            string token = CreateJWT(user);

            return Ok(token);
        }

        private string CreateJWT(UserAuthent userAuthent)
        {
            List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, userAuthent.UserName) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}

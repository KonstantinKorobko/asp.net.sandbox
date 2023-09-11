using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Helpers
{
    public class Authentication
    {
        private readonly IConfiguration Configuration;
        private readonly AuthenticationPar? AuthenticationParam;
        private readonly SymmetricSecurityKey SecurityKey;
        private readonly SigningCredentials Credentials;
        public Authentication(IConfiguration _configuration)
        {
            Configuration = _configuration;
            AuthenticationParam = Configuration.GetSection(AuthenticationPar.Authentication).Get<AuthenticationPar>();
            SecurityKey = new(Encoding.UTF8.GetBytes(AuthenticationParam.IssuerSigningKey));
            Credentials = new(SecurityKey, SecurityAlgorithms.HmacSha256Signature);
        }

        public string GetJWT(Guid _id)
        {
            List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, _id.ToString("D")) };

            JwtSecurityToken token = new(
                issuer: AuthenticationParam.Issuer,
                audience: AuthenticationParam.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Int32.Parse(AuthenticationParam.JWTExpire)),
                signingCredentials: Credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

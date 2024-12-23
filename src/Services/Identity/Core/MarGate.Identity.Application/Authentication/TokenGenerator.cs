using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarGate.Identity.Application.Authentication
{
    public interface ITokenGenerator
    {
        public string GenerateAccessToken(long userId);
    }

    public class TokenGenerator(IConfiguration configuration) : ITokenGenerator
    {
        public string GenerateAccessToken(long userId)
        {
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JwtToken:SecurityKey"));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim("userId", userId.ToString())
                ]),

                Expires = DateTime.Now.AddMinutes(configuration.GetValue<int>("JwtToken:TokenExpiresInMinutes")),
                Issuer = configuration.GetValue<string>("JwtToken:Issuer"),
                Audience = configuration.GetValue<string>("JwtToken:Audience"),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}

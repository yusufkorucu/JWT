using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Jwt.TokenAPI.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Dto.Token CreateToken()
        {
            var token = new Dto.Token();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Token expire Settings

            token.ExpiryDate = DateTime.UtcNow.AddHours(1);

            var securityToken = new JwtSecurityToken(

                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.ExpiryDate,
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials

                );

            token.AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}

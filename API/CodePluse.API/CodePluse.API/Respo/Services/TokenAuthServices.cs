using CodePluse.API.Respo.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodePluse.API.Respo.Services
{
    public class TokenAuthServices : ITokenAuth
    {
        private readonly IConfiguration _configuration;
        public TokenAuthServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       

        public string CreateJWTToken(IdentityUser user, List<string> roles)
        {
            //Create Clims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),

            };
            claims.AddRange(roles.Select(roles=>new Claim(ClaimTypes.Role, roles)));

            //JWT S 
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credintals=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires:DateTime.Now.AddMinutes(15),
                signingCredentials: credintals  );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}



using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyJsonWebToken.Controllers
{
    public class TokenController:Controller
    {
        private const string SECRET_KEY = "alvaro_siles_estrada_llave_secret";
         public static readonly SymmetricSecurityKey SIGNING_KEY = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        //alvaro_siles_estrada_llave_secret

       [HttpGet]
        [Route("api/token/{username}/{password}")]

        public IActionResult Get(string username, string password)
        {
            /*if(username == password)
                return new ObjectResult(GenerateToken("romeo santos"));
            else
                return BadRequest();*/

            if (username == password)
                return new ObjectResult(GenerateToken(username));
            else
                return BadRequest();
        }

        private string GenerateToken (string username)
        {
            var token = new JwtSecurityToken(
                   claims: new Claim[] { new Claim(ClaimTypes.Name, username) },
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
            signingCredentials: new SigningCredentials(SIGNING_KEY,
                                                SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}

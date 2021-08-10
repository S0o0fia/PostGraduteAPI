using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniWebAPI.Interface;
using UniWebAPI.Models;
using UniWebAPI.ViewModel;

namespace UniWebAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService (IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string CreatToken(PostGradutesInfo user)
        {
            var claim = new List<Claim>
          {
             new Claim (JwtRegisteredClaimNames.NameId, user.Email)

          };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var TokenHandler = new JwtSecurityTokenHandler();

            var token = TokenHandler.CreateToken(tokenDescriptor);

            return TokenHandler.WriteToken(token);

        }
    }
}

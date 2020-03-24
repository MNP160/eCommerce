using eCommerceFrontend.Models.REST.Manager;
using eCommerceFrontend.Models.REST.Objects.Registration;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceFrontend.Utility
{
    public class TokenProvider
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        public string LoginUser(string email, string password)
        {
            AuthenticationManager authenticationManager = new AuthenticationManager(_clientFactory, _contextAccessor);
            var response = authenticationManager.Post(email, password);
            
            if (response != null)
            {
                var key = Encoding.ASCII.GetBytes("7XToJ1QCxtr6DxHln9S7qUcLrFjsAobivdJH7plZxF5rsn3anPYdYRdN7yCSxMvd");

                var JWToken = new JwtSecurityToken(
                   issuer: "usersAPI",
                   audience: "everybody",
                   claims: GetUserClaims(response.Token),
                   notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                   expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                   //Using HS256 Algorithm to encrypt Token  
                   signingCredentials: new SigningCredentials
                   (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
               );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return token;
            }
            else
            {
                return null;
            }
        }

        private IEnumerable<Claim> GetUserClaims(string token)
        {
            var stream = token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
            var role = tokenS.Claims.First(claim => claim.Type == "role").Value;

            IEnumerable<Claim> claims = new Claim[]
            {
                new Claim(ClaimTypes.Role, role)
            };
            return claims;
        }
    }
}

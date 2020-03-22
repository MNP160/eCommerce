using eCommerceFrontend.Models.REST.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
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

            if (response == null)
                return null;
            else
            {
                return response.Token.ToString();
            }
        }
    }
}

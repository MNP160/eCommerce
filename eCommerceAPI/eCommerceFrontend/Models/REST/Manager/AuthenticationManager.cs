using eCommerceFrontend.Models.REST.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class AuthenticationManager: RESTManager<AuthenticationResponse, AuthenticationRequest>
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthenticationManager(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public AuthenticationResponse Post(string email, string password)
        {
            return base.Post(new AuthenticationRequest { Email = email, Password = password }, "User", "Authenticate").Result;
        }
    }
}

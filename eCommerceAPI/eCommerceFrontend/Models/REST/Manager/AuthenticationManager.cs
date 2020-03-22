using eCommerceFrontend.Models.REST.Objects;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthenticationManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(clientFactory, contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        public AuthenticationResponse Post(string email, string password)
        {
            return base.Post(new AuthenticationRequest { Email = email, Password = password }, "User", "authenticate").Result;
        }
    }
}

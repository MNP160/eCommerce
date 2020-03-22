using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class RegistrationManager : RESTManager<UserResponse, RegisterRequest>
    {
        private readonly IHttpClientFactory _clientFactory;

        public RegistrationManager(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public UserResponse Post(RegisterRequest user)
        {
            return base.Post(user, "User", "register").Result;
        }
    }
}

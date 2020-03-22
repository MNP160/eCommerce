using eCommerceFrontend.Models.REST.Objects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class UserManager : RESTManager<UserResponse, UserRequest>
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserManager(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public new UserResponse Get(string id)
        {
            return base.Get("User", id).Result;
        }

        public List<UserResponse> Get()
        {
            return base.Get("User").Result.ToList();
        }
    }
}

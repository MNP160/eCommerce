using eCommerceFrontend.Models.REST.Objects;
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

        public UserResponse Get(string id)
        {
            return base.Get("User", id).Result;
        }

        public List<UserResponse> Get()
        {
            return base.Get("User").Result.ToList();
        }

        public UserResponse Post(UserRequest user, string id = null)
        {
            return base.Post(user, "User", id).Result;
        }

        public UserResponse Put(UserRequest user)
        {
            return base.Put(user, "User").Result;
        }

        public UserResponse Delete(string id)
        {
            return base.Delete("User", id).Result;
        }
    }

}

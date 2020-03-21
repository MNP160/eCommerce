using eCommerceFrontend.Models.REST.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class UserManager : RESTManager<User>
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserManager(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public new User Get(string id)
        {
            return base.Get("User", id).Result;
        }

        public new List<User> Get()
        {
            return base.Get("User").Result.ToList();
        }

        public new User Post(User user)
        {
            return base.Post(user, "User").Result;
        }

        public new User Put(User user, string id)
        {
            return base.Put(user, "User", id).Result;
        }

        public new User Delete(string id)
        {
            return base.Delete("User", id).Result;
        }
    }

}

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
        private readonly IHttpContextAccessor _contextAccessor;


        public UserManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(clientFactory, contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        public new UserResponse Get(string id)
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

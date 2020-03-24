using eCommerceFrontend.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Controllers
{
    public class UsersController : Controller
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IHttpClientFactory _clientFactory;


        public UsersController(ILogger<UsersController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }


        public IActionResult Login(string email, string password)
        {
            //var userToken = new TokenProvider(_clientFactory).LoginUser(email.Trim(), password.Trim());
            //if (userToken != null)
            //{
            //    AppContext.Current.Session.Set<string>("token", userToken);
            //}
            return Redirect("~/Home/Index");
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }



    }
}

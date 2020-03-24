using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eCommerceFrontend.Models;
using eCommerceFrontend.Models.REST.Manager;
using System.Net.Http;
using eCommerceFrontend.Utility;
using Microsoft.AspNetCore.Http;
using eCommerceFrontend.Models.REST.Objects;
using System.Net.Http.Headers;

namespace eCommerceFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            LoginUser("admin5@gmail.com", "bestPassword");
            UserManager um = new UserManager(_clientFactory, _contextAccessor);
            System.Diagnostics.Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(um.Get(), Newtonsoft.Json.Formatting.Indented));
            OrderManager om = new OrderManager(_clientFactory, _contextAccessor);
            System.Diagnostics.Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(om.Get(), Newtonsoft.Json.Formatting.Indented));

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LoginUser(string email, string password)
        {
            TokenProvider tokenProvider = new TokenProvider(_clientFactory, _contextAccessor);
            var userToken = tokenProvider.LoginUser(email, password);
            
            if (userToken != null)
            {
                HttpContext.Session.SetString("JWToken", userToken);
                var client = _clientFactory.CreateClient("ecoproduce");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
            }
            return Redirect("~/Home/Index");
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }
    }
}

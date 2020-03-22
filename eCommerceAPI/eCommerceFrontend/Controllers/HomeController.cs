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
using AppContext = eCommerceFrontend.Utility.AppContext;

namespace eCommerceFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;


        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            LoginUser("admin3@gmail.com", "bestPassword");
            UserManager um = new UserManager(_clientFactory);
            System.Diagnostics.Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(um.Get("1"), Newtonsoft.Json.Formatting.Indented));
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
            var userToken = new TokenProvider(_clientFactory).LoginUser(email.Trim(), password.Trim());
            if (userToken != null)
            {
                AppContext.Current.Session.Set<string>("token", userToken);
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

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
            LoginUser("admin3@gmail.com", "bestPassword");
            UserManager um = new UserManager(_clientFactory, _contextAccessor);
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
            TokenProvider _tokenProvider = new TokenProvider(_clientFactory, _contextAccessor);
            //Authenticate user
            var userToken = _tokenProvider.LoginUser(email.Trim(), password.Trim());
            if (userToken != null)
            {
                _contextAccessor.HttpContext.Request.Headers.Add("Authorization", $"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjMiLCJuYmYiOjE1ODQ3OTc1NTgsImV4cCI6MTU4NDg4Mzk1OCwiaWF0IjoxNTg0Nzk3NTU4LCJpc3MiOiJ1c2Vyc0FQSSIsImF1ZCI6ImV2ZXJ5Ym9keSJ9.VI7vIw2tvwdEIB2U0wXetLgedHgsrsm_prG7WsmsBIk");
                //Save token in session object
                //HttpContext.Session.SetString("JWToken", userToken);
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

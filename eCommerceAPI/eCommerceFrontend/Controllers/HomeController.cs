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
using eCommerceFrontend.Models.REST.Objects.Cathegory;

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
            CathegoryManager cm = new CathegoryManager(_clientFactory, _contextAccessor);
            var categories= cm.Get();
            

            return View(categories);
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

        
       
    }
}

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
using eCommerceFrontend.Models.View.Home_Model;

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

        public IActionResult Index(string id = null)
        {
            List<int> ids = new List<int>();
            CathegoryManager cm = new CathegoryManager(_clientFactory, _contextAccessor);
            var allCategories = cm.Get();
            var selectedCategories = allCategories; // If no categories are selected, display all.

            if (id != null && id.Length > 0)
            {
                ids = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(id);
                selectedCategories = allCategories.Where(x => ids.Contains(x.Id)).ToList(); // Categories w/ id from List<int> ids
            }

            return View(new IndexView(allCategories, selectedCategories, ids));
        }

        public IActionResult AddCategoryId(string id, string selectedIds = null)
        {
            List<int> allIds = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(selectedIds);
            int currentId = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(id);
            allIds.Add(currentId);
            allIds.Distinct();
            string serializedIds = Newtonsoft.Json.JsonConvert.SerializeObject(allIds);
            return RedirectToAction("Index", "Home", new { id = serializedIds });
        }

        public IActionResult RemoveCategoryId(string id, string selectedIds)
        {
            List<int> allIds = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(selectedIds);
            int currentId = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(id);
            allIds.RemoveAll(x => x == currentId);
            allIds.Distinct();
            string serializedIds = Newtonsoft.Json.JsonConvert.SerializeObject(allIds);
            return RedirectToAction("Index", "Home", new { id = serializedIds });
        }

        public IActionResult BuyItem(int id)
        {
            ProductManager pm = new ProductManager(_clientFactory, _contextAccessor);
            ProductResponse product = pm.Get($"{id}");
            return View(product);
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

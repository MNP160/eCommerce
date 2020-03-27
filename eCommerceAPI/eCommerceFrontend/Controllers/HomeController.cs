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

        public IActionResult Index(int pageNum = 1, int pageSize = 4, int? category = null, string search = null)
        {
            List<int> ids = new List<int>(); // delete later

            CathegoryManager cm = new CathegoryManager(_clientFactory, _contextAccessor);
            var allCategories = cm.Get();
            var selectedCategories = allCategories; // If no categories are selected, display all.

            // If a category is selected
            // And that category id exists
            // And that category contains more than 1 product
            // Then display items for that category
            // Otherwise display all
            if (category != null && selectedCategories.Any(x => x.Id == category && x.Products.Count > 0))
            {
                selectedCategories = allCategories.Where(x => x.Id == category).ToList();
            }

            List<ProductResponse> allProducts = new List<ProductResponse>();
            // Adds all products to a list
            foreach(var currentCategory in selectedCategories)
            {
                // product list needs to be separate from the category response for pagination
                if(currentCategory.Products != null && currentCategory.Products.Count > 0)
                {
                    allProducts.AddRange(currentCategory.Products);
                }
            }

            if(search != null && search.Length > 2)
            {
                var foundProducts = allProducts.Where(x => x.Name.ToUpper().Contains(search.ToUpper())).ToList();
                if (foundProducts.Count > 0)
                    allProducts = foundProducts;
                else
                    allProducts.Clear();
            }

            // Example: 54 products, 10 per page
            // 54/10 = 5
            // 54%10 = 4 -> 4 != 0 -> TotalPages++
            int totalPages = allProducts.Count / pageSize;
            if (allProducts.Count % pageSize != 0)
                totalPages++;

            // Get the required products
            allProducts = allProducts.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();

            return View(new IndexView(allCategories, allProducts, pageNum, pageSize, category, totalPages, search));
        }

        public IActionResult AddCategory(string pageNum, string pageSize, string categoryId)
        {
            int pageNumInt = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(pageNum);
            int pageSizeInt = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(pageSize);
            int categoryIdInt = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(categoryId);

            return RedirectToAction("Index", "Home", new { pageNum = pageNumInt, pageSize = pageSizeInt, category = categoryIdInt });
        }

        public IActionResult RemoveCategory(string pageNum, string pageSize, string categoryId)
        {
            int pageNumInt = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(pageNum);
            int pageSizeInt = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(pageSize);

            return RedirectToAction("Index", "Home", new { pageNum = pageNumInt, pageSize = pageSizeInt});
        }

        public IActionResult UpdateModel(string pageNum, string pageSize, string? categoryId, string search)
        {
            int pageNumInt = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(pageNum);
            int pageSizeInt = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(pageSize);
            int? categoryIdInt = null;
            if(categoryId != null)
                categoryIdInt = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(categoryId);
            return RedirectToAction("Index", "Home", new { pageNum = pageNumInt, pageSize = pageSizeInt, category = categoryIdInt, search = search });
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

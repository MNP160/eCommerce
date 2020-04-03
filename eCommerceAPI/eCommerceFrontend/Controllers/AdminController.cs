using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eCommerceFrontend.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using AuthorizeAttribute = eCommerceFrontend.Utility.AuthorizeAttribute;
using eCommerceFrontend.Models.REST.Manager;
using Microsoft.AspNetCore.Http;
using eCommerceFrontend.Models.REST.Objects.Order;
using eCommerceFrontend.Models.View.Admin_Model;
using Newtonsoft.Json;
using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Orders;
using eCommerceFrontend.Models.REST.Objects.Product;
using System.Threading;
using System.IO;
using eCommerceFrontend.Models.REST.Objects.Cathegory;

namespace eCommerceFrontend.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;
        
        public AdminController(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        [Authorize(Roles.USER)]
        public IActionResult Index()
        {
            OrderManager orderManager = new OrderManager(_clientFactory, _contextAccessor);
            List<OrdersResponse> orders = orderManager.Get();
            List<OrdersResponse> acceptedOrders = orders.Where(x => x.Stage == 1).ToList();
            List<OrdersResponse> processingOrders = orders.Where(x => x.Stage == 2).ToList();
            List<OrdersResponse> travellingOrders = orders.Where(x => x.Stage == 3).ToList();
            List<OrdersResponse> deliveredOrders = orders.Where(x => x.Stage == 4).ToList();
            
            return View(new AdminView(acceptedOrders, processingOrders, travellingOrders, deliveredOrders));
        }

        private string getStage(int orderStatus)
        {
            switch (orderStatus)
            {
                case 1:
                    return "Accepted";
                case 2:
                    return "Processing";
                case 3:
                    return "Travelling";
                case 4:
                    return "Delivered";
                default:
                    return "N/A";
            }
        }

        public IActionResult ViewOrderItems(int order)
        {
            OrderManager orderManager = new OrderManager(_clientFactory, _contextAccessor);
            OrdersResponse currentOrder = orderManager.Get($"{order}");

            List<OrderDetailsResponse> products = currentOrder.OrderDetails.ToList();

            return View(new OrderDetailsView(products));
        }

        public IActionResult ViewCategory()
        {
            CathegoryManager cm = new CathegoryManager(_clientFactory, _contextAccessor);
            List<CathegoryResponse> categories = cm.Get();
            return View(categories);
        }

        public IActionResult ViewProduct()
        {
            ProductManager pm = new ProductManager(_clientFactory, _contextAccessor);
            List<ProductResponse> products = pm.Get();
            CathegoryManager cm = new CathegoryManager(_clientFactory, _contextAccessor);
            List<CathegoryResponse> categories = cm.Get();
            return View(new ProductView(products, categories));
        }

        public IActionResult ViewSizes(string id)
        {
            ProductManager pm = new ProductManager(_clientFactory, _contextAccessor);
            ProductResponse product = pm.Get(id);
            return View(product);
        }

        #region Redirect 

        public IActionResult AddProduct(string name, string longDescription, string shortDescription,
            double originalPrice, double actualPrice, bool isLive, string? size1, string? size2, 
            string? size3, string? size4, string? size5, int? value1, int? value2, int? value3, int? value4,
            int? value5, int categoryId, IFormFile file)
        {
            Dictionary<string, int> size = new Dictionary<string, int>();

            int quantity = 0;
            if (!String.IsNullOrEmpty(size1) && value1.HasValue)
            {
                size.Add(size1, value1.Value);
                quantity += value1.Value;
            }
            if (!String.IsNullOrEmpty(size2) && value2.HasValue)
            {
                size.Add(size2, value2.Value);
                quantity += value2.Value;
            }
            if (!String.IsNullOrEmpty(size3) && value3.HasValue)
            {
                size.Add(size3, value3.Value);
                quantity += value3.Value;
            }
            if (!String.IsNullOrEmpty(size4) && value4.HasValue)
            {
                size.Add(size4, value4.Value);
                quantity += value4.Value;
            }
            if (!String.IsNullOrEmpty(size5) && value5.HasValue)
            {
                size.Add(size5, value5.Value);
                quantity += value5.Value;
            }


            ProductRequest request = new ProductRequest
            {
                Name = name,
                ProductSKU = Guid.NewGuid().ToString(),
                LongDescription = longDescription,
                ShortDescription = shortDescription,
                OriginalPrice = originalPrice,
                ActualPrice = actualPrice,
                IsLive = isLive,
                Size = size,
                CathegoryId = categoryId
            };

            ProductPostRequest productPost = new ProductPostRequest(request, file);
            ProductPostManager ppm = new ProductPostManager(_clientFactory, _contextAccessor);
         
            ppm.Post(request, file);

            return RedirectToAction("ViewProduct");
        }

        public IActionResult AddSize(int id, string key, int value)
        {
            ProductManager pm = new ProductManager(_clientFactory, _contextAccessor);
            ProductResponse product = pm.Get($"{id}");

            var dictionary = product.Size[0];
            dictionary.Add(key, value);

            CathegoryManager cm = new CathegoryManager(_clientFactory, _contextAccessor);
            var cathegories = cm.Get();
            int categoryId = cathegories.Where(x => x.Products.Contains(product)).Select(x => x.Id).FirstOrDefault();

            ProductRequest request = new ProductRequest
            {
                Name = product.Name,
                ProductSKU = product.ProductSKU,
                LongDescription = product.LongDescription,
                ShortDescription = product.ShortDescription,
                OriginalPrice = product.OriginalPrice,
                ActualPrice = product.ActualPrice,
                IsLive = product.IsLive,
                Size = dictionary,
                CathegoryId = categoryId
            };

            pm.Put(request);

            return RedirectToAction("ViewSizes", "Admin");
        }

        public IActionResult RemoveSize(string id, string key)
        {
            ProductManager pm = new ProductManager(_clientFactory, _contextAccessor);
            ProductResponse product = pm.Get(id);

            var dictionary = product.Size[0];
            dictionary.Remove(key);

            CathegoryManager cm = new CathegoryManager(_clientFactory, _contextAccessor);
            var cathegories = cm.Get();
            int categoryId = cathegories.Where(x => x.Products.Contains(product)).Select(x => x.Id).FirstOrDefault();

            ProductRequest request = new ProductRequest
            {
                Name = product.Name,
                ProductSKU = product.ProductSKU,
                LongDescription = product.LongDescription,
                ShortDescription = product.ShortDescription,
                OriginalPrice = product.OriginalPrice,
                ActualPrice = product.ActualPrice,
                IsLive = product.IsLive,
                Size = dictionary,
                CathegoryId = categoryId
            };

            pm.Put(request);

            return RedirectToAction("ViewSizes", "Admin");
        }

        public IActionResult AddCategory(string name)
        {
            CathegoryManager cm = new CathegoryManager(_clientFactory, _contextAccessor);
            CathegoryRequest request = new CathegoryRequest() { Name = name };
            cm.Post(request);
            return RedirectToAction("ViewCategory", "Admin");
        }

        public IActionResult MoveForward(int id)
        {
            OrderManager orderManager = new OrderManager(_clientFactory, _contextAccessor);
            OrdersResponse orderResponse = orderManager.Get($"{id}");

            if ((orderResponse.Stage + 1) > 4)
                return NotFound();

            OrderRequest orderRequest = new OrderRequest
            {
                OrderSKU = orderResponse.OrderSKU,
                OrderDate = orderResponse.OrderDate,
                TotalAmount = orderResponse.TotalAmount,
                Phone = orderResponse.Phone,
                City = orderResponse.City,
                Address = orderResponse.Address,
                Address2 = orderResponse.Address2,
                OrderEmail = orderResponse.OrderEmail,
                OrderZipCode = orderResponse.OrderZipCode,
                Stage = orderResponse.Stage + 1
            };

            orderManager.Put(orderRequest);

            return RedirectToAction("Index");
        }
        public IActionResult MoveBack(int id)
        {
            OrderManager orderManager = new OrderManager(_clientFactory, _contextAccessor);
            OrdersResponse orderResponse = orderManager.Get($"{id}");

            if ((orderResponse.Stage + 1) < 1)
                return NotFound();

            OrderRequest orderRequest = new OrderRequest
            {
                OrderSKU = orderResponse.OrderSKU,
                OrderDate = orderResponse.OrderDate,
                TotalAmount = orderResponse.TotalAmount,
                Phone = orderResponse.Phone,
                City = orderResponse.City,
                Address = orderResponse.Address,
                Address2 = orderResponse.Address2,
                OrderEmail = orderResponse.OrderEmail,
                OrderZipCode = orderResponse.OrderZipCode,
                Stage = orderResponse.Stage - 1
            };

            orderManager.Put(orderRequest);

            return RedirectToAction("Index");
        }
        #endregion
    }
}

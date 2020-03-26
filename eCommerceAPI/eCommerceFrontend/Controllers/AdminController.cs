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
            List<OrdersResponse> fulfilledOrders = orders.Where(x => x.IsOrderComplete).ToList();
            List<OrdersResponse> unfulfilledOrders = orders.Where(x => !x.IsOrderComplete).ToList();

            return View(new AdminView(fulfilledOrders, unfulfilledOrders));
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

        public IActionResult AddCategory(string name)
        {
            CathegoryManager cm = new CathegoryManager(_clientFactory, _contextAccessor);
            CathegoryRequest request = new CathegoryRequest() { Name = name };
            cm.Post(request);
            return RedirectToAction("ViewCategory", "Admin");
        }

        public IActionResult ViewProduct()
        {
            ProductManager pm = new ProductManager(_clientFactory, _contextAccessor);
            List<ProductResponse> products = pm.Get();
            return View(products);
        }

        public IActionResult AddProduct(string name, string longDescription, string shortDescription,
            double originalPrice, double actualPrice, int quantity, bool isLive, int sCount, int mCount,
            int lCount, int xlCount, int categoryId, IFormFile file)
        {
            System.Diagnostics.Debug.WriteLine($"{file.FileName}");
            return RedirectToAction("ViewProduct", "Admin");
        }



        public IActionResult AddProductx()
        {
            ProductManager productManager = new ProductManager(_clientFactory, _contextAccessor);
            return View();
        }


        public IActionResult UploadFile(IFormFile file)
        {
            System.Diagnostics.Debug.WriteLine($"SUCCESS: {file.FileName}");
            return RedirectToAction("Index");
        }

        public IActionResult FulfilOrder(int id)
        {
            OrderManager orderManager = new OrderManager(_clientFactory, _contextAccessor);
            OrdersResponse orderResponse = orderManager.Get($"{id}");
            OrderRequest orderRequest = new OrderRequest
            {
                TotalAmount = orderResponse.TotalAmount,
                Phone = orderResponse.Phone,
                City = orderResponse.City,
                Address = orderResponse.Address,
                Address2 = orderResponse.Address2,
                OrderEmail = orderResponse.OrderEmail,
                OrderZipCode = orderResponse.OrderZipCode,
                Size = orderResponse.Size,
                IsCashPayment = orderResponse.IsCashPayment,
                IsOrderComplete = true
            };

            orderManager.Put(orderRequest);

            return RedirectToAction("Index");
        }

        public IActionResult UnfulfilOrder(int id)
        {
            OrderManager orderManager = new OrderManager(_clientFactory, _contextAccessor);
            OrdersResponse orderResponse = orderManager.Get($"{id}");
            OrderRequest orderRequest = new OrderRequest
            {
                TotalAmount = orderResponse.TotalAmount,
                Phone = orderResponse.Phone,
                City = orderResponse.City,
                Address = orderResponse.Address,
                Address2 = orderResponse.Address2,
                OrderEmail = orderResponse.OrderEmail,
                OrderZipCode = orderResponse.OrderZipCode,
                Size = orderResponse.Size,
                IsCashPayment = orderResponse.IsCashPayment,
                IsOrderComplete = false
            };

            orderManager.Put(orderRequest);

            return RedirectToAction("Index");
        }
    }
}

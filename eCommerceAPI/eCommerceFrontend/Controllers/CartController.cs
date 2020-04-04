using eCommerceFrontend.Helpers;
using eCommerceFrontend.Models.REST.Manager;
using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Orders;
using eCommerceFrontend.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Controllers
{
    public class CartController:Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public CartController(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        //[Authorize(Roles.USER)]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFronJson<List<OrderDetailsRequest>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                ViewBag.cart = cart;
                ViewBag.Total = cart.Sum(item => item.DetailPrice * item.DetailQuantity);
                return View(cart);
            }
            else
            {
                return View(cart);
            }
        }



        public IActionResult BuyCart(double TotalAmount, string Phone, string City, string Address, string Address2, string OrderEmail, string OrderZipCode)
        {
            byte[] emailByteArray;
            HttpContext.Session.TryGetValue("email", out emailByteArray);

            var email = System.Text.Encoding.Default.GetString(emailByteArray);

            UserManager um = new UserManager(_clientFactory, _contextAccessor);
            List<UserResponse> allUsers = um.Get();
            var currentUser = allUsers.FirstOrDefault(x=>x.Email==email);

            OrderManager om = new OrderManager(_clientFactory, _contextAccessor);
            OrderRequest or = new OrderRequest();
            or.Address = Address;
            or.Address2 = Address2;
            or.City = City;
            or.OrderEmail = OrderEmail;
            or.TotalAmount = TotalAmount;
            or.OrderZipCode = OrderZipCode;
            or.Phone = Phone;
            or.OrderSKU = new Guid().ToString();
            or.OrderDate = DateTime.UtcNow.ToString();
            or.Stage = 1;
            or.UserId = currentUser.Id;
            var responce =  om.Post(or);

            OrderItemsManager odm = new OrderItemsManager(_clientFactory, _contextAccessor);

            List<OrderDetailsRequest> cart = SessionHelper.GetObjectFronJson<List<OrderDetailsRequest>>(HttpContext.Session, "cart");
            foreach(var item in cart)
            {
                item.OrderId = responce.Id;
                odm.Post(item);
            }

            HttpContext.Session.Remove("cart");

            return RedirectToAction("Index", "Home");
        }



        public IActionResult AddToCart(string name, double price, int quantity, string sku, string size, string imagePath)
        {
            if(SessionHelper.GetObjectFronJson<List<OrderDetailsRequest>>(HttpContext.Session, "cart") == null)
            {
                
                List<OrderDetailsRequest> cart = new List<OrderDetailsRequest>();
                cart.Add(new OrderDetailsRequest { DetailName = name, DetailPrice = (price*quantity), DetailQuantity=quantity, DetailsSKU = sku, Size = size, ThumbnailPath = imagePath});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }
            else
            {
                List<OrderDetailsRequest> cart = SessionHelper.GetObjectFronJson<List<OrderDetailsRequest>>(HttpContext.Session, "cart");
                int index = IsExists(name);
                if (index != -1)
                {
                    cart[index].DetailQuantity++;
                }
                else
                {
                    cart.Add(new OrderDetailsRequest { DetailName = name, DetailPrice = (price * quantity), DetailQuantity = quantity, DetailsSKU = sku, Size = size, ThumbnailPath = imagePath });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");

        }



        public IActionResult Remove(string name)
        {
            List<OrderDetailsRequest> cart = SessionHelper.GetObjectFronJson<List<OrderDetailsRequest>>(HttpContext.Session, "cart");

            int index = IsExists(name);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }


        [NonAction]

        private int IsExists(string name)
        {
            List<OrderDetailsRequest> cart = SessionHelper.GetObjectFronJson<List<OrderDetailsRequest>>(HttpContext.Session, "cart");

            for(int i=0; i<cart.Count; i++)
            {
                if (cart[i].DetailName.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }


    }
}

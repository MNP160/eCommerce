using eCommerceFrontend.Models.REST.Manager;
using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Registration;
using eCommerceFrontend.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eCommerceFrontend.Controllers
{
    public class UsersController : Controller
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public UsersController(ILogger<UsersController> logger, IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Orders()
        {
            byte[] emailByteArray;
            HttpContext.Session.TryGetValue("email", out emailByteArray);

            var email = System.Text.Encoding.Default.GetString(emailByteArray);
            
            UserManager um = new UserManager(_clientFactory, _contextAccessor);
            List<UserResponse> allUsers = um.Get();
            int currentId = allUsers.Where(x => x.Email == email).Select(x => x.Id).FirstOrDefault();
            UserResponse user = um.Get($"{currentId}");

            // Get Full Token
            /*var containsBearerToken = _contextAccessor.HttpContext.Request.Headers.ContainsKey("Authorization");
            if(containsBearerToken == false)
                return NotFound();

            Microsoft.Extensions.Primitives.StringValues token;
            var bearerToken = _contextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token.ToString().Split(' ')[1]);
            var tokenS = handler.ReadToken(token.ToString().Split(' ')[1]) as JwtSecurityToken;
            var userId = tokenS.Claims.First(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/unique_name").Value;
            */

            return View(user);
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest request)
        {
            RegistrationManager rm = new RegistrationManager(_clientFactory, _contextAccessor);
           var responce= rm.Post(request);
            if (responce != null)
            {
                TokenProvider tokenProvider = new TokenProvider(_clientFactory, _contextAccessor);
                var userToken = tokenProvider.LoginUser(request.Email, request.Password);

                if (userToken != null)
                {
                    HttpContext.Session.SetString("JWToken", userToken);
                    var client = _clientFactory.CreateClient("ecoproduce");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
                    return RedirectToAction("Index", "Home");
                }
               
            }
            else
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }


        [HttpPost]
        public IActionResult Login(AuthenticationRequest request)
        {
            TokenProvider tokenProvider = new TokenProvider(_clientFactory, _contextAccessor);
            var userToken = tokenProvider.LoginUser(request.Email, request.Password);

            if (userToken != null)
            {
                HttpContext.Session.SetString("JWToken", userToken);
                HttpContext.Session.SetString("email", request.Email);
                var client = _clientFactory.CreateClient("ecoproduce");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
                return Redirect("~/Home/Index");
            }
            return View();
        }


        public IActionResult Logoff()
        {
            HttpContext.Session.Remove("JWToken");
            return Redirect("~/Home/Index");
        }



    }
}

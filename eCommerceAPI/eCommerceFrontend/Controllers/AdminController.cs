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

namespace eCommerceFrontend.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        
        public AdminController(IHttpClientFactory clientFactory)
        {

        }

        [Authorize(Roles.USER)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
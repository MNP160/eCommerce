using eCommerceAPI.DTOs;
using eCommerceAPI.Models;
using eCommerceAPI.Repositories;
using farmersAPi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController :BasicController<Orders, OrdersRepository, OrdersDto>
    {
        public OrdersController(OrdersRepository repository) : base(repository)
        {

        }

    }
}

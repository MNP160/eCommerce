using eCommerceAPI.DTOs;
using eCommerceAPI.Models;
using eCommerceAPI.Repositories;
using farmersAPi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Controllers
{
    public class OrderItemsController :BasicController<OrderItems, OrderItemsRepository, OrderItemsDto>
    {
        public OrderItemsController(OrderItemsRepository repository) : base(repository)
        {

        }

    }
}

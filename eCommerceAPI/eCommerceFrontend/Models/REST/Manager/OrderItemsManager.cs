using eCommerceFrontend.Models.REST.Objects.Orders;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class OrderItemsManager : RESTManager<OrderDetailsResponse, OrderDetailsRequest>
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;
        public OrderItemsManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(clientFactory, contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        public new OrderDetailsResponse Get(string id)
        {
            return base.Get("OrderItems", id).Result;
        }

        public List<OrderDetailsResponse> Get()
        {
            return base.Get("OrderItems").Result.ToList();
        }

        public OrderDetailsResponse Post(OrderDetailsRequest orderItem)
        {
            return base.Post(orderItem, "OrderItems", null).Result;
        }

        public OrderDetailsResponse Put(OrderDetailsRequest orderItem)
        {
            return base.Put(orderItem, "OrderItems").Result;
        }

        public OrderDetailsResponse Delete(string id)
        {
            return base.Delete("OrderItems", id).Result;
        }
    }
}

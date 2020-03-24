using eCommerceFrontend.Models.REST.Objects.Orders;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class OrderItemsManager : RESTManager<OrderItemsResponse, OrderItemsRequest>
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;
        public OrderItemsManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(clientFactory, contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        public new OrderItemsResponse Get(string id)
        {
            return base.Get("OrderItems", id).Result;
        }

        public List<OrderItemsResponse> Get()
        {
            return base.Get("OrderItems").Result.ToList();
        }

        public OrderItemsResponse Post(OrderItemsRequest orderItem)
        {
            return base.Post(orderItem, "OrderItems", null).Result;
        }

        public OrderItemsResponse Put(OrderItemsRequest orderItem)
        {
            return base.Put(orderItem, "OrderItems").Result;
        }

        public OrderItemsResponse Delete(string id)
        {
            return base.Delete("OrderItems", id).Result;
        }
    }
}

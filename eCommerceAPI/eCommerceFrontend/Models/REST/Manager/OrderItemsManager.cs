using eCommerceFrontend.Models.REST.Objects.Orders;
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

        public OrderItemsManager(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
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

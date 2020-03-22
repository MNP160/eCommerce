using eCommerceFrontend.Models.REST.Objects.Order;
using eCommerceFrontend.Models.REST.Objects.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class OrderManager : RESTManager<OrdersResponse, OrderRequest>
    {
        private readonly IHttpClientFactory _clientFactory;

        public OrderManager(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public new OrdersResponse Get(string id)
        {
            return base.Get("Orders", id).Result;
        }

        public List<OrdersResponse> Get()
        {
            return base.Get("Orders").Result.ToList();
        }

        public OrdersResponse Post(OrderRequest order)
        {
            return base.Post(order, "Orders", null).Result;
        }

        public OrdersResponse Put(OrderRequest order)
        {
            return base.Put(order, "Orders").Result;
        }

        public OrdersResponse Delete(string id)
        {
            return base.Delete("Orders", id).Result;
        }
    }
}

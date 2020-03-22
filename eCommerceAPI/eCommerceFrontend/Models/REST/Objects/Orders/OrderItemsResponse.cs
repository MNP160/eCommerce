using eCommerceFrontend.Models.REST.Objects.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Orders
{
    public class OrderItemsResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductResponse  Product { get; set; }
        public int OrderId { get; set; }
        public OrdersResponse Order { get; set; }
    }
}

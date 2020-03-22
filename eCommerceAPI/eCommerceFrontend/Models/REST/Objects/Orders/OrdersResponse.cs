using eCommerceFrontend.Models.REST.Objects.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Order
{
    public class OrdersResponse
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public int UserId { get; set; }
        public UserResponse User { get; set; }
        public List<OrderItemsResponse> OrderItems { get; set; }
    }
}

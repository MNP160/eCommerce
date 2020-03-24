using eCommerceFrontend.Models.REST.Objects.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Order
{
    public class OrdersResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public UserResponse User { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }

        public bool isCashPayment { get; set; }
        public bool isOrderComplete { get; set; }

        [Required]
        public List<OrderItemsResponse> OrderItems { get; set; }
    }
}

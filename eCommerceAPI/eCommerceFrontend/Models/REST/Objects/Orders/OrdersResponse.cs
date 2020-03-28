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
        public string OrderSKU { get; set; }
        public double TotalAmount { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string OrderDate { get; set; }
        public string OrderEmail { get; set; }
        public string OrderZipCode { get; set; }
        public string Size { get; set; }
        public int Stage { get; set; }
        public List<OrderDetailsResponse> OrderDetails { get; set; }
    }
}

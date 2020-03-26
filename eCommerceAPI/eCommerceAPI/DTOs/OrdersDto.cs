using eCommerceAPI.Interfaces;
using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.DTOs
{
    public class OrdersDto : IDto
    {

        public int Id { get; set; }

        public double TotalAmount { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string OrderDate { get; set; } 
        public string OrderEmail { get; set; }
        public string OrderZipCode { get; set; }
        public string Size { get; set; }
        public bool IsCashPayment { get; set; }
        public bool IsOrderComplete { get; set; }
        public string OrderSKU { get; set; }
        public ICollection<OrderDetailsDto> OrderDetails { get; set; }
    }
}

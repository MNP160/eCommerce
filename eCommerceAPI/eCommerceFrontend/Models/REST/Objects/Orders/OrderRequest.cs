using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Orders
{
    public class OrderRequest
    {
        public double TotalAmount { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? UserId { get; set; }
        public bool isCashPayment { get; set; }
        public bool isOrderComplete { get; set; }
    }
}

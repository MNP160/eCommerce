using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Orders
{
    public class OrderRequest
    {
        public double TotalAmount { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string OrderEmail { get; set; }
        public string OrderZipCode { get; set; }
        public string Size { get; set; }

        public bool IsCashPayment { get; set; }
        public bool IsOrderComplete { get; set; }
    }
}

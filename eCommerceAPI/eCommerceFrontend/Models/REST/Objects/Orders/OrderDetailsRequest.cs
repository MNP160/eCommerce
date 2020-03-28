using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Orders
{
    public class OrderDetailsRequest
    {
        public string Size { get; set; }
        public string ImagePath { get; set; }
        public string DetailName { get; set; }
        public double DetailPrice { get; set; }
        public int DetailQuantity { get; set; }
        public string DetailsSKU { get; set; }
        public int OrderId { get; set; }
    }
}

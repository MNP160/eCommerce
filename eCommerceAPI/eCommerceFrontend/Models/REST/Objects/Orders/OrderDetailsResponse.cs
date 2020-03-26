using eCommerceFrontend.Models.REST.Objects.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Orders
{
    public class OrderDetailsResponse
    {
        public string DetailsName { get; set; }
        public string DatailsPrice { get; set; }
        public string DetailSKU { get; set; }
        public int DetailsQuantity { get; set; }
    }
}

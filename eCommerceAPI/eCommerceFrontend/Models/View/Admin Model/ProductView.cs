using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.View.Admin_Model
{
    public class ProductView
    {
        public List<OrderDetailsResponse> Products = new List<OrderDetailsResponse>();

        public ProductView(List<OrderDetailsResponse> products)
        {
            Products = products;
        }
    }
}

using eCommerceFrontend.Models.REST.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.View.Admin_Model
{
    public class ProductView
    {
        public List<ProductResponse> Products = new List<ProductResponse>();

        public ProductView(List<ProductResponse> products)
        {
            Products = products;
        }
    }
}

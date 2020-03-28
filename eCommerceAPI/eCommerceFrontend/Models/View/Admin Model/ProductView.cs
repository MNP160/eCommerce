using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Cathegory;
using eCommerceFrontend.Models.REST.Objects.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.View.Admin_Model
{
    public class ProductView
    {
        public List<ProductResponse> Products = new List<ProductResponse>();
        public List<CathegoryResponse> Categories = new List<CathegoryResponse>();

        public ProductView(List<ProductResponse> products, List<CathegoryResponse> categories)
        {
            Products = products;
            Categories = categories;
        }
    }
}

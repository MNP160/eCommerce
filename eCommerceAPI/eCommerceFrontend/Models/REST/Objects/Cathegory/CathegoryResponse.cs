using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Cathegory
{
    public class CathegoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductResponse> Products {get; set;}
    }
}

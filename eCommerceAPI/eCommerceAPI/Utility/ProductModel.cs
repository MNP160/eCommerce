using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Utility
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? CathegoryId { get; set; }

        public int? UserId { get; set; }

    }
}

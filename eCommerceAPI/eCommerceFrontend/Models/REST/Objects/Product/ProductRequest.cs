using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Product
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }

        public int SCount { get; set; } 
        public int MCount { get; set; } 
        public int LCount { get; set; } 
        public int XLCount { get; set; } 

        public int? CathegoryId { get; set; }
    }
}

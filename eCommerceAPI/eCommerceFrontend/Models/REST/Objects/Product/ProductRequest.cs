using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Product
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public double OriginalPrice { get; set; }
        public double ActualPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsLive { get; set; }
        public int SCount { get; set; } 
        public int MCount { get; set; } 
        public int LCount { get; set; } 
        public int XLCount { get; set; } 
        public int CathegoryId { get; set; }
    }
}

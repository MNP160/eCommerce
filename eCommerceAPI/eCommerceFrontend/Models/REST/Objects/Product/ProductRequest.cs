using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Product
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string ProductSKU { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public double OriginalPrice { get; set; }
        public double ActualPrice { get; set; }
        public bool IsLive { get; set; }

        public string ImagePath { get; set; }
        public Dictionary<string, int> Size { get; set; }
        public int CategoryId { get; set; }
    }
}

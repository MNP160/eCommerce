using eCommerceAPI.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Utility
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        
        public double OriginalPrice { get; set; }
        public double ActualPrice { get; set; }

        public List<ProductQuantity> Size { get; set; }
        public bool IsLive { get; set; }
        public string ProductSKU { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailPath { get; set; }
    }
}

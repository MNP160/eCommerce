using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Utility
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        
        public double OriginalPrice { get; set; }
        public double ActualPrice { get; set; }
        
        public int Quantity { get; set; }
        public bool IsLive { get; set; }
        public int SCount { get; set; } = 0;
        public int MCount { get; set; } = 0;
        public int LCount { get; set; } = 0;
        public int XLCount { get; set; } = 0;
        public int CategoryId { get; set; }

    }
}

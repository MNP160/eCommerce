using eCommerceAPI.Interfaces;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.DTOs
{
    public class ProductDto :IDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public double OriginalPrice { get; set; }
        public double ActualPrice { get; set; }
        public string ProductSKU { get; set; }
        public Dictionary<string, int> Size { get; set; } = new Dictionary<string, int>();
        public bool IsLive { get; set; }
      

        //public CathegoryDto cathegory { get; set; }





    }
}

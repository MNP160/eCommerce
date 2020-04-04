using eCommerceFrontend.Models.REST.Objects.Cathegory;
using eCommerceFrontend.Models.REST.Objects.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects
{
    public class ProductResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailPath { get; set; }

        public double OriginalPrice { get; set; }
        public double ActualPrice { get; set; }
        public string ProductSKU { get; set; }
        public int Quantity { get; set; }
        public bool IsLive { get; set; }
       /*
        public int SCount { get; set; } 
        public int MCount { get; set; }
        public int LCount { get; set; }
        public int XLCount { get; set; }
        */
        public List<ProductQuantity> Size { get; set; }
        public int CategoryId { get; set; }

    }
}

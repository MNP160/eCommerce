﻿using eCommerceAPI.Interfaces;
using eCommerceAPI.Utility;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.DTOs
{
    public class ProductDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public double OriginalPrice { get; set; }
        public double ActualPrice { get; set; }
        public string ProductSKU { get; set; }
        public List<ProductQuantity> Size { get; set; }
        public bool IsLive { get; set; }
       public int Quantity { get
            {
                return Size.Sum(x => x.Quantity);
            }
        }
        public string ThumbnailPath { get; set; }

        public int CategoryId { get; set; }
        //public CathegoryDto cathegory { get; set; }





    }
}

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
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }

        public int Discount { get; set; }

        public int SCount { get; set; } = 0;
        public int MCount { get; set; } = 0;
        public int LCount { get; set; } = 0;
        public int XLCount { get; set; } = 0;

        //public CathegoryDto cathegory { get; set; }





    }
}

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
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }

        public CathegoryDto cathegory { get; set; }

        public ProductUserDto user { get; set; }

        public ICollection<ToxinsDto> toxins { get; set; }
               
    }
}

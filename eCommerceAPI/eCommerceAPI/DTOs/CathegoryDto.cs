using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.DTOs
{
    public class CathegoryDto :IDto
    {

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

       // public ICollection<ProductDto> products { get; set; }

    }
}

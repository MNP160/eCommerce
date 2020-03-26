using eCommerceAPI.Interfaces;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.DTOs
{
    public class CategoryDto :IDto
    {

        public int Id { get; set; }
       
        public string Name { get; set; }
     

        public virtual ICollection<ProductDto> products { get; set; }

    }
}

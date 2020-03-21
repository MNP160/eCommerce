using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.DTOs
{
    public class OrderItemsDto :IDto
    {

        public int Id { get; set; }

        public ICollection<ProductDto> Products { get; set; }
    }
}

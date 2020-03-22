using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.DTOs
{
    public class OrderItemsDto :IBasicDto
    {
      
       

        public ProductDto Product { get; set; }
    }
}

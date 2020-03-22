using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.DTOs
{
    public class OrderItemProductDto: IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

    }
}

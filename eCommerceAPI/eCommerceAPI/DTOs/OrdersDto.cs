using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.DTOs
{
    public class OrdersDto :IDto, IBasicDto
    {

        public int Id { get; set; }

        public ICollection<OrderItemsDto> orderItems { get; set; }
    }
}

using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.DTOs
{
    public class OrdersDto : IDto, IBasicDto
    {

        public int Id { get; set; }
             
        public int Phone { get; set; }
        public string City { get; set; }

        public string Address { get; set; }

        public bool isCashPayment { get; set; }
        public bool isOrderComplete { get; set; }

        public UserDto user { get; set; }
        public ICollection<OrderItemsDto> orderItems { get; set; }
    }
}

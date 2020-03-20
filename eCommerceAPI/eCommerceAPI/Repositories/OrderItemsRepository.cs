using AutoMapper;
using eCommerceAPI.DTOs;
using eCommerceAPI.Models;
using farmersAPi.Models;
using farmersAPi.Repositories;


namespace eCommerceAPI.Repositories
{
    public class OrderItemsRepository :BasicRepository<OrderItems, APIContext, OrderItemsDto>
    {

        private APIContext _context;
        private IMapper mapper;
        public OrderItemsRepository(APIContext context, IMapper map) : base(context, map)
        {
            _context = context;
            mapper = map;
        }
    }
}

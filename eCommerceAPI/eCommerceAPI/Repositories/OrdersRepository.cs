using AutoMapper;
using eCommerceAPI.DTOs;
using eCommerceAPI.Models;
using farmersAPi.Models;
using farmersAPi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Repositories
{
    public class OrdersRepository :BasicRepository<Orders, APIContext, OrdersDto>
    {
        private APIContext _context;
        private IMapper mapper;
        public OrdersRepository(APIContext context, IMapper map) : base(context, map)
        {
            _context = context;
            mapper = map;
        }

    }
}

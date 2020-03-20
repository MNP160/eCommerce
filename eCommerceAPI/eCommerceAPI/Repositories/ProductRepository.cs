using AutoMapper;
using farmersAPi.DTOs;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Repositories
{
    public class ProductRepository: BasicRepository<Product, APIContext, ProductDto>
    {
        private APIContext _context;
        private IMapper mapper;
        public ProductRepository(APIContext context, IMapper map) : base(context, map)
        {
            _context = context;
              mapper = map;
        }


    }
}

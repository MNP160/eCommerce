using AutoMapper;
using farmersAPi.DTOs;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Repositories
{
    public class ToxinsRepository :BasicRepository<Toxins, APIContext, ToxinsDto>
    {
        private APIContext _context;
        private IMapper mapper;
        public ToxinsRepository(APIContext context, IMapper map) : base(context, map)
        {
            _context = context;
              mapper = map;
        }

    }
}

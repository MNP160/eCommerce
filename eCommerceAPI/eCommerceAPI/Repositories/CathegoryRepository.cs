using AutoMapper;
using farmersAPi.DTOs;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Repositories
{
    public class CathegoryRepository : BasicRepository<Cathegory, APIContext,CathegoryDto>
    {
        private APIContext _context;
        private IMapper mapper;
        public CathegoryRepository(APIContext context, IMapper map) :base(context, map)
        {
            _context = context;
            mapper = map;
        }

    }
}

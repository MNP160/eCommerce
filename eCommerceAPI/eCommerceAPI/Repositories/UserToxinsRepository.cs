using AutoMapper;
using farmersAPi.DTOs;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Repositories
{
    public class UserToxinsRepository :BasicRepository<UserToxins, APIContext, UserToxinsDto>
    {
        private APIContext _context;
        private IMapper mapper;
        public UserToxinsRepository(APIContext context, IMapper map) : base(context, map)
        {
            _context = context;
            mapper = map;
        }

    }
}

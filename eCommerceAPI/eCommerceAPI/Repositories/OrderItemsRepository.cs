using AutoMapper;
using eCommerceAPI.DTOs;
using eCommerceAPI.Extensions;
using eCommerceAPI.Models;
using eCommerceAPI.QueryParameters;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Repositories
{
    public class OrderItemsRepository
    {

        private readonly APIContext _context;
        private IMapper _mapper;

        public OrderItemsRepository(APIContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }

        public async Task<OrderItems> Create(OrderItems value)
        {

            _context.Set<OrderItems>().Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<OrderItems> Delete(OrderItems value)
        {
            _context.Set<OrderItems>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }


        public async Task<PagedList<OrderItemsDto>> Select(GenericParameters parameters)
        {
            
            return PagedList<OrderItemsDto>.ToPagedList(FindAll(), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<OrderItems> Update(OrderItems value)
        {
            var editedEntity = _context.Set<OrderItems>().FirstOrDefault(e => e.Id == value.Id);
            editedEntity = value;
            _context.Update(editedEntity);
            await _context.SaveChangesAsync();
            return value;

        }

        public IQueryable<OrderItemsDto> FindAll()
        {
            var entities = _context.Set<OrderItems>();
            var dtos = _mapper.Map<IList<OrderItemsDto>>(entities);
            return dtos.AsQueryable();
        }

    }
}

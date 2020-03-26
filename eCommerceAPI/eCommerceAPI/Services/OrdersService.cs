using eCommerceAPI.DTOs;
using eCommerceAPI.Extensions;
using eCommerceAPI.Models;
using eCommerceAPI.QueryParameters;
using eCommerceAPI.Repositories;
using farmersAPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Services
{
    public class OrdersService :IService<OrdersRepository, Orders, OrdersDto>
    {
        private readonly OrdersRepository _repository;

        public OrdersService(OrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<OrdersDto>> Read(GenericParameters parameters)
        {
            return await _repository.Read(parameters);
        }


        public async Task<OrdersDto> ReadById(int Id)
        {
            return await _repository.ReadById(Id);
        }

        public async Task<Orders> Create(Orders value)
        {
            return await _repository.Create(value);
        }

        public async Task<Orders> Update(Orders value)
        {
            return await _repository.Update(value);
        }

        public async Task<Orders> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<Orders> Delete(Orders value)
        {
            return await _repository.Delete(value);
        }



    }
}

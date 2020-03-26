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
    public class OrderDetailsService :IService<OrderDetailsRepository, OrderDetails, OrderDetailsDto>
    {

        private readonly OrderDetailsRepository _repository;

        public OrderDetailsService(OrderDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<OrderDetailsDto>> Read(GenericParameters parameters)
        {
            return await _repository.Read(parameters);
        }


        public async Task<OrderDetailsDto> ReadById(int Id)
        {
            return await _repository.ReadById(Id);
        }

        public async Task<OrderDetails> Create(OrderDetails value)
        {
            return await _repository.Create(value);
        }

        public async Task<OrderDetails> Update(OrderDetails value)
        {
            return await _repository.Update(value);
        }

        public async Task<OrderDetails> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<OrderDetails> Delete(OrderDetails value)
        {
            return await _repository.Delete(value);
        }

    }
}

using eCommerceAPI.Extensions;
using eCommerceAPI.QueryParameters;
using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using farmersAPi.Models;
using farmersAPi.Repositories;
using farmersAPi.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Services
{
    public class ProductService :IService<ProductRepository, Products, ProductDto>
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<ProductDto>> Read(GenericParameters parameters)
        {
            return await _repository.Read(parameters);
        }


        public async Task<ProductDto> ReadById(int Id)
        {
            return await _repository.ReadById(Id);
        }
        public async Task<Products> Create (Products value)
        {
            return await _repository.Create(value);
        }

        public async Task<ProductDto> Create(ProductRequest value)
        {
            return await _repository.Create(value);
        }
        public async Task<List<string>> Create(IFormFile file)
        {
            return await _repository.Create(file);
        }

        public async Task<Products> Update(Products value)
        {
            return await _repository.Update(value);
        }

        public async Task<Products> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<Products> Delete(Products value)
        {
            return await _repository.Delete(value);
        }


    }
}

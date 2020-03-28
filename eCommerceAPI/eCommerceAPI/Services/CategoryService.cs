using eCommerceAPI.Extensions;
using eCommerceAPI.QueryParameters;
using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using farmersAPi.Models;
using farmersAPi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Services
{
    public class CategoryService :IService<CategoryRepository, Categories, CategoryDto>
    {
        private readonly CategoryRepository _repository;

        public CategoryService(CategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<CategoryDto>> Read(GenericParameters parameters)
        {
           return await _repository.Read(parameters);
        }


        public async Task<CategoryDto> ReadById(int Id)
        {
            return await _repository.ReadById(Id);
        }

        public async Task<Categories> Create (Categories value)
        {


            return await _repository.Create(value);
        }

        public async Task<Categories> Update(Categories value)
        {
            return await _repository.Update(value);
        }

        public async Task<Categories> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<Categories> Delete (Categories value)
        {
            return await _repository.Delete(value);
        }




    }
}

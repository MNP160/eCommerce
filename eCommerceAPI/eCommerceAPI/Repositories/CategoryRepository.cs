using AutoMapper;
using eCommerceAPI.Extensions;
using eCommerceAPI.QueryParameters;
using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Repositories
{
    public class CategoryRepository : IRepository<Categories, CategoryDto>
    {
        private readonly APIContext _context;
        private IMapper _mapper;

        public CategoryRepository(APIContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }

        public async Task<Categories> Create(Categories value)
        {

            _context.Set<Categories>().Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Categories> Delete(Categories value)
        {
            _context.Set<Categories>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }
        public async Task<Categories> Delete(int Id)
        {
            var entityToDelete = _context.Category.FirstOrDefault(x => x.Id == Id);
            if (entityToDelete != null)
            {
                _context.Category.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return entityToDelete;
            }
            else
            {
                return null;
            }
        }


        public async Task<PagedList<CategoryDto>> Read(GenericParameters parameters)
        {

            return await Task.Run(()=> PagedList<CategoryDto>.ToPagedList(FindAll(), parameters.PageNumber, parameters.PageSize));
        }

        public async Task<CategoryDto> ReadById(int Id)
        {
            var entityToReturn = await _context.Category.FindAsync(Id);
            if (entityToReturn != null)
            {
                var dto = _mapper.Map<CategoryDto>(entityToReturn);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Categories> Update(Categories value)
        {
            var editedEntity = _context.Set<Categories>().FirstOrDefault(e => e.Id== value.Id);
            editedEntity = value;
            _context.Update(editedEntity);
            await _context.SaveChangesAsync();
            return value;

        }

        public IQueryable<CategoryDto> FindAll()
        {
            var entities = _context.Set<Categories>();
            var dtos = _mapper.Map<IList<CategoryDto>>(entities);
            return dtos.AsQueryable();
        }

    }
}

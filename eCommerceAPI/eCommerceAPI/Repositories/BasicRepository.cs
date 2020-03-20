using AutoMapper;
using farmersAPi.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Repositories
{
    public abstract class BasicRepository<TEntity,TContext,TDto> : IRepository<TEntity, TDto> 
        where TEntity : class, IEntity 
        where TContext : DbContext
        where TDto :IDto
    {
        private TContext _context;
        private IMapper mapper;
        public BasicRepository(TContext context, IMapper map)
        {
            _context = context;
            mapper = map;
        }

        public async Task<TEntity> Delete(int Id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(Id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            

            return entity;
        }

        public async Task<TDto> SelectbyId(int Id)
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(Id);
            TDto dto = mapper.Map<TDto>(entity);
            return dto;
        }

      public  async Task<TEntity>  Create(TEntity value)
        {

           _context.Set<TEntity>().Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public  async Task<TEntity> Delete(TEntity value)
        {
            _context.Set<TEntity>().Remove(value);
           await _context.SaveChangesAsync();
            return value;


        }
           

      public  async Task<IList<TDto>> Select()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            IList<TDto> dtos = mapper.Map<IList<TDto>>(entities);
            return dtos;
        }

     public    async Task<TEntity> Update(TEntity value)
        {
            var editedEntity = _context.Set<TEntity>().FirstOrDefault(e => e.Id == value.Id);
            editedEntity = value;
            _context.Update(editedEntity);
            await _context.SaveChangesAsync();
            return value;

        }


    }
}

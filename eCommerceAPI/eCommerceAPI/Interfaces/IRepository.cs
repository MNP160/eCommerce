
using eCommerceAPI.Extensions;
using eCommerceAPI.Interfaces;
using eCommerceAPI.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Interfaces
{
    public interface IRepository<TEntity, TDto> where TEntity : class, IEntity
        where TDto:IDto
    {
       

       Task<PagedList<TDto>> Select(GenericParameters parameters);
        Task<TDto> SelectbyId(int Id);
       Task<TEntity> Update(TEntity value);
        Task<TEntity> Delete(TEntity value);
       Task<TEntity> Delete(int Id);
       Task<TEntity> Create(TEntity value);


    }
}

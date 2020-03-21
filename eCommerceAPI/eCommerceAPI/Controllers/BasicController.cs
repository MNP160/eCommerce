using eCommerceAPI.Filtering;
using farmersAPi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public abstract class BasicController<TEntity, TRepository, TDto> : ControllerBase
        where TEntity: class, IEntity
        where TRepository:IRepository<TEntity, TDto>
        where TDto:IDto
    {
        private readonly TRepository _repository;

        public BasicController(TRepository repository)
        {
            this._repository = repository;
        }


        [HttpGet("")]

        public async Task<ActionResult<PagedCollectionResponce<TDto>>> Get([FromQuery] BasicFilter filter)
        {
            var results = new PagedCollectionResponce<TDto>
            {
                Items = await _repository.Select(filter)
            };

            BasicFilter nextFilter = filter.Clone() as BasicFilter;
            nextFilter.Page += 1;
            string nextUrl = results.Items.Count() <= 0 ? null : this.Url.Action("Get", null, nextFilter, Request.Scheme);

            
            BasicFilter previousFilter = filter.Clone() as BasicFilter;
            previousFilter.Page -= 1;
            string previousUrl = previousFilter.Page <= 0 ? null : this.Url.Action("Get", null, previousFilter, Request.Scheme);

            results.NextPage = !string.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl) : null;
            results.PreviousPage = !string.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl) : null;

            return Ok( results);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<TEntity>> Get(int Id)
        {
            var value = await _repository.SelectbyId(Id);

            if(value == null)
            {
                return NotFound();
            }

            return Ok(value);

        }


        [HttpPut("")]
        public async Task<IActionResult> Put(TEntity value)
        {

           var entity= await _repository.Update(value);
            return Ok(entity);

        }

        [HttpPost("")]

        public async Task<ActionResult<TEntity>> Post(TEntity value)
        {
          var entity=  await _repository.Create(value);

            return Ok(entity);
        } 

        [HttpDelete("{id}")]

        public async Task<ActionResult<TEntity>> Delete(int Id)
        {
           var entity= await _repository.Delete(Id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);

        }
    }
}

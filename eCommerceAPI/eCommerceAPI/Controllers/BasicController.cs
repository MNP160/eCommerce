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

        public async Task<ActionResult<List<TEntity>>> Get()
        {

            return Ok( await _repository.Select());
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

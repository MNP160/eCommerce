using eCommerceAPI.QueryParameters;
using eCommerceAPI.Services;
using farmersAPi.DTOs;
using farmersAPi.Models;
using farmersAPi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    { 

        private CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;

        }


        [HttpGet("")]

        public async Task<ActionResult<List<CategoryDto>>> Get([FromQuery] GenericParameters parameters)
        {
            var values = await _service.Read(parameters);
            if (values != null)
            {
                var metadata = new
                {
                    values.TotalCount,
                    values.PageSize,
                    values.CurrentPage,
                    values.TotalPages,
                    values.HasNext,
                    values.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                return Ok(values);
            }
            else
            {
                return BadRequest("something broke");
            }

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var dto = await _service.ReadById(id);
            if (dto != null)
            {
                return Ok(dto);
            }

            else
            {
                return BadRequest("Didnt find Item");
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> Put(Categories value)
        {

            var entity = await _service.Update(value);

            if (entity != null)
                return Ok(entity);
            else
            {
                return BadRequest("something broke");
            }


        }

        [HttpPost("")]

        public async Task<ActionResult<Categories>> Post(Categories value)
        {
            var entity = await _service.Create(value);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest("something broke ");
            }

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Categories>> Delete(int id)
        {
            var entity = await _service.Delete(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);

        }

    }
}

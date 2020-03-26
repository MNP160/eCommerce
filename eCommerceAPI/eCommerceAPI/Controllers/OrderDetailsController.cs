using eCommerceAPI.DTOs;
using eCommerceAPI.Models;
using eCommerceAPI.QueryParameters;
using eCommerceAPI.Repositories;
using eCommerceAPI.Services;
using farmersAPi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private OrderDetailsService _service;

        public OrderDetailsController(OrderDetailsService service)
        {
            _service = service;

        }


        [HttpGet("")]

        public async Task<ActionResult<List<OrderDetailsDto>>> Get([FromQuery] GenericParameters parameters)
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

        public async Task<ActionResult<OrderDetailsDto>> Get(int id)
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
        public async Task<IActionResult> Put(OrderDetails value)
        {

            var entity = await _service.Update(value);

            if(entity !=null)
                return Ok(entity);
            else
            {
                return BadRequest("something broke");
            }


        }

        [HttpPost("")]

        public async Task<ActionResult<OrderDetails>> Post(OrderDetails value)
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

        public async Task<ActionResult<OrderDetails>> Delete(int id)
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

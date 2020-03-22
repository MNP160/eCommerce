using eCommerceAPI.Models;
using eCommerceAPI.QueryParameters;
using eCommerceAPI.Repositories;
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
    public class OrderItemsController :ControllerBase
    {
        private OrderItemsRepository _repository;

        public OrderItemsController(OrderItemsRepository repository)
        {
            _repository = repository;

        }


        [HttpGet("")]

        public async Task<ActionResult<List<OrderItems>>> Get([FromQuery] GenericParameters parameters)
        {
            var values = await _repository.Select(parameters);

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


      


        [HttpPut("")]
        public async Task<IActionResult> Put(OrderItems value)
        {

            var entity = await _repository.Update(value);
            return Ok(entity);

        }

        [HttpPost("")]

        public async Task<ActionResult<OrderItems>> Post(OrderItems value)
        {
            var entity = await _repository.Create(value);

            return Ok(entity);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<OrderItems>> Delete(OrderItems orderItem)
        {
            var entity = await _repository.Delete(orderItem);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);

        }

    }
}

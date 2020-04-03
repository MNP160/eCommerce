using AutoMapper;
using eCommerceAPI.QueryParameters;
using eCommerceAPI.Services;
using eCommerceAPI.Utility;
using farmersAPi.DTOs;
using farmersAPi.Models;
using farmersAPi.Repositories;
using farmersAPi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

    public class ProductController :ControllerBase
    {
        private ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;

        }


        [HttpGet("")]

        public async Task<ActionResult<List<Products>>> Get([FromQuery] GenericParameters parameters)
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

        public async Task<ActionResult<Products>> Get(int id)
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
        public async Task<IActionResult> Put(Products value)
        {

            var entity = await _service.Update(value);

            if (entity != null)
                return Ok(entity);
            else
            {
                return BadRequest("something broke");
            }


        }

       

        [HttpDelete("{id}")]

        public async Task<ActionResult<Products>> Delete(int id)
        {
            var entity = await _service.Delete(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);

        }


        [HttpPost("")]
       


        public async Task<ActionResult<Products>> Post([FromBody]ProductRequest ProductRequest)
        {
           var createdProduct= await _service.Create(ProductRequest);
            if (createdProduct != null)
            {
                return Ok(createdProduct);
            }
            else
            {
                return BadRequest("something broke");
            }
           
        }


        [HttpPost]
        [Route("addImage")]
        public async Task<ActionResult<string>> Post(IFormFile file)
        {
            string path="";
           // if (Request.HasFormContentType)
            {
            //    var form = Request.Form;
             //   foreach (var file in form.Files)
               // {
                    path = await _service.Create(file);
                //}
            }
            if (!string.IsNullOrEmpty(path))
            {
                return Ok(path);
            }
            else
            {
                return BadRequest("file not written successfully");
            }
        }

    }
}

using AutoMapper;
using farmersAPi.DTOs;
using farmersAPi.Models;
using farmersAPi.Repositories;
using farmersAPi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductController : BasicController<Product, ProductRepository, ProductDto>
    {
        private IMapper mapper;
        private IImageHandler _handler;
        private APIContext _context;
        public ProductController(ProductRepository repository, IMapper map, IImageHandler handler, APIContext context): base(repository)
        {
            mapper = map;
            _handler = handler;
            _context = context;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public  async Task<ActionResult<Product>> Post([FromForm]ProductModel value, IFormFile file)
        {
            var product = mapper.Map<Product>(value);
            var filename= await _handler.UploadImage(file);
            product.ImagePath = new Uri($"{Request.Scheme}://{Request.Host}/images/"+filename, UriKind.Absolute).ToString();
            _context.Product.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }

    }
}

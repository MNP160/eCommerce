using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Product
{
    public class ProductPostRequest
    {
        public ProductRequest ProductRequest { get; set; }
        public IFormFile IFormFile { get; set; }

        public ProductPostRequest(ProductRequest productRequest, IFormFile iFormFile)
        {
            ProductRequest = productRequest;
            IFormFile = iFormFile;
        }
    }
}

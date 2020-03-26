using farmersAPi.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Utility
{
    public class ProductPostRequest
    {
        public ProductModel model { get; set; }
        public IFormFile file { get; set; }

    }
}

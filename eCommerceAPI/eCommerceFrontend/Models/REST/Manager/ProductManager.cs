using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Product;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class ProductManager : RESTManager<ProductResponse, ProductRequest>
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base (clientFactory, contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        public new ProductResponse Get(string id)
        {
            return base.Get("Product", id).Result;
        }

        public List<ProductResponse> Get()
        {
            return base.Get("Product").Result.ToList();
        }

        public ProductResponse Post(ProductRequest product)
        {
            return base.Post(product, "Product", "create").Result;
        }

        public ProductResponse Post(ProductRequest product, IFormFile file)
        {
            return base.Post(product, "Product", "create").Result;
        }

        public ProductResponse Put(ProductRequest product)
        {
            return base.Put(product, "Product").Result;
        }

        public ProductResponse Delete(string id)
        {
            return base.Delete("Product", id).Result;
        }
    }

    public class ProductPostManager : RESTManager<ProductResponse, ProductPostRequest>
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductPostManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(clientFactory, contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
            
        }

        public ProductResponse Post(ProductPostRequest product)
        {


            return base.Post(product, "Product", null).Result;
        }
    }
}

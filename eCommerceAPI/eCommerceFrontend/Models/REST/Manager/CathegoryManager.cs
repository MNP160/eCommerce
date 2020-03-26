using eCommerceFrontend.Models.REST.Objects.Cathegory;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class CathegoryManager : RESTManager<CathegoryResponse, CathegoryRequest>
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public CathegoryManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(clientFactory, contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }

        public new CathegoryResponse Get(string id)
        {
            return base.Get("Category", id).Result;
        }

        public List<CathegoryResponse> Get()
        {
            return base.Get("Category").Result.ToList();
        }

        public CathegoryResponse Post(CathegoryRequest cathegory)
        {
            return base.Post(cathegory, "Category", null).Result;
        }

        public CathegoryResponse Put(CathegoryRequest cathegory)
        {
            return base.Put(cathegory, "Category").Result;
        }

        public CathegoryResponse Delete(string id)
        {
            return base.Delete("Category", id).Result;
        }
    }
}

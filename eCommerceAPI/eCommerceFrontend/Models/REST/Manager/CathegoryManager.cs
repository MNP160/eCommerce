using eCommerceFrontend.Models.REST.Objects.Cathegory;
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
        public CathegoryManager(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public new CathegoryResponse Get(string id)
        {
            return base.Get("Cathegory", id).Result;
        }

        public List<CathegoryResponse> Get()
        {
            return base.Get("Cathegory").Result.ToList();
        }

        public CathegoryResponse Post(CathegoryRequest cathegory)
        {
            return base.Post(cathegory, "Cathegory", null).Result;
        }

        public CathegoryResponse Put(CathegoryRequest cathegory)
        {
            return base.Put(cathegory, "Cathegory").Result;
        }

        public CathegoryResponse Delete(string id)
        {
            return base.Delete("Cathegory", id).Result;
        }
    }
}

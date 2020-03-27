using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Manager
{
    public interface IRestManager<T, U> where T : class where U : class
    {
        public Task<T> Get(string controller, string id = null);
        public Task<IEnumerable<T>> Get(string controller);
        public Task<T> Post(U postObject, string controller, string id = null);

        
        public Task<T> Put(U putObject, string controller);
        public Task<T> Delete(string controller, string id);
    }
}

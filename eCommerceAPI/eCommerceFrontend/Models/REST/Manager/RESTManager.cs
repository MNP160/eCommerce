using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class RESTManager<T> where T: class
    {
        private readonly IHttpClientFactory _clientFactory;

        public RESTManager(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<T> Get(string controller, string action, string id)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            var response = await client.GetAsync($"{controller}//{action}//{id}");

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }

        [HttpPost]
        public async Task<T> Post(string controller, string action, string id, T postObject)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            var content = new StringContent(postObject.ToString());
            var response = await client.PostAsync($"{controller}//{action}//{id}", content).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }

        [HttpPut]
        public async Task<T> Put(string controller, string action, string id, T putObject)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            var content = new StringContent(putObject.ToString());
            var response = await client.PutAsync($"{controller}//{action}//{id}", content).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }

        [HttpDelete]
        public async Task<T> Delete(string controller, string action, string id)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            var response = await client.DeleteAsync($"{controller}//{action}//{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using eCommerceFrontend.Models.REST.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerceFrontend.Models.REST.Manager
{
    public class RESTManager<T> where T: class
    {
        private readonly IHttpClientFactory _clientFactory;

        protected internal RESTManager(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        protected internal async Task<T> Get(string controller, string id = null)
        {
            T result = null;


            var client = _clientFactory.CreateClient("ecoproduce");
            string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
            var response = await client.GetAsync(path);

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }

        [HttpGet]
        protected internal async Task<IEnumerable<T>> Get(string controller)
        {
            IEnumerable<T> result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            string path = $"api/{controller}";
            var response = await client.GetAsync(path);

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<IEnumerable<T>>(x.Result);
            });

            return result;
        }

        [HttpPost]
        protected internal async Task<T> Post(T postObject, string controller, string id = null)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            var content = new StringContent(postObject.ToString());
            string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
            var response = await client.PostAsync(path, content).ConfigureAwait(false);
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
        protected internal async Task<T> Put(T putObject, string controller)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            var content = new StringContent(putObject.ToString());
            string path = $"api/{controller}";
            var response = await client.PutAsync(path, content).ConfigureAwait(false);
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
        protected internal async Task<T> Delete(string controller, string id)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            string path = $"api/{controller}/{id}";
            var response = await client.DeleteAsync(path).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });

            return result;
        }

        [HttpPost]
        protected internal async Task<T> Authenticate(string email, string password)
        {
            T result = null;

            var client = _clientFactory.CreateClient("ecoproduce");
            var content = new StringContent(new AuthenticationRequest { Email = email, Password = password }.ToString());
            string path = $"api/User/Authenticate";
            var response = await client.PostAsync(path, content).ConfigureAwait(false);
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

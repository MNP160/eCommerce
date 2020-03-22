﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using eCommerceFrontend.Models.REST.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerceFrontend.Models.REST.Manager
{
    public abstract class RESTManager<T, U>: IRestManager<T, U>
        where T: class
        where U : class
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;
        private HttpClient client;

        protected internal RESTManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
            client = clientFactory.CreateClient("ecoproduce");

            if (contextAccessor.HttpContext.Request.Headers.Any(x => x.Key == "Authorization"))
            {
                var dict = _contextAccessor.HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault();
                System.Diagnostics.Debug.WriteLine($"FOUND TOKEN: {dict.Value}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjMiLCJuYmYiOjE1ODQ3OTc1NTgsImV4cCI6MTU4NDg4Mzk1OCwiaWF0IjoxNTg0Nzk3NTU4LCJpc3MiOiJ1c2Vyc0FQSSIsImF1ZCI6ImV2ZXJ5Ym9keSJ9.VI7vIw2tvwdEIB2U0wXetLgedHgsrsm_prG7WsmsBIk");
            }

        }

        [HttpGet]
        public async Task<T> Get(string controller, string id)
        {
            T result = null;
            System.Diagnostics.Debug.WriteLine($"COUNT INSIDE: {client.DefaultRequestHeaders.Count()}");
            System.Diagnostics.Debug.WriteLine($"COUNT INSIDE: {client.DefaultRequestHeaders.First().Value.ToString()}");

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
        public async Task<IEnumerable<T>> Get(string controller)
        {
            IEnumerable<T> result = null;

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
        public async Task<T> Post(U postObject, string controller, string id)
        {
            T result = null;
            System.Diagnostics.Debug.WriteLine($"COUNT INSIDE: {client.DefaultRequestHeaders.Count()}");

            var content = new StringContent(JsonConvert.SerializeObject(postObject), System.Text.Encoding.UTF8, "application/json");
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
        public async Task<T> Put(U putObject, string controller)
        {
            T result = null;

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
        public async Task<T> Delete(string controller, string id)
        {
            T result = null;

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

        private Task AddToken(ref HttpClient client)
        {
            if(_contextAccessor.HttpContext.Request.Headers.Any(x => x.Key == "Authorization"))
            {
                var dict = _contextAccessor.HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault();
                System.Diagnostics.Debug.WriteLine($"TOKEN {dict.Value}");
                client.DefaultRequestHeaders.Add("Autorization", $"{dict.Value}");
                System.Diagnostics.Debug.WriteLine($"COUNT INSIDE: {client.DefaultRequestHeaders.Count()}");
            }
            return Task.CompletedTask;
        }
    }
}

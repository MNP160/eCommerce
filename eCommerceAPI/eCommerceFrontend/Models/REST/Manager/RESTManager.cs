using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Product;
using eCommerceFrontend.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace eCommerceFrontend.Models.REST.Manager
{
    public abstract class RESTManager<ProductResponce, U>: IRestManager<ProductResponce, U>
        where ProductResponce: class
        where U : class
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string _token;

        protected internal RESTManager(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
            _token = contextAccessor.HttpContext.Session.GetString("JWToken");
        }

        [HttpGet]
        public async Task<ProductResponce> Get(string controller, string id)
        {
            ProductResponce result = null;

            var client = _clientFactory.CreateClient("ecoproduce").AddJwt(_token);
            string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
            var response = await client.GetAsync(path);

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<ProductResponce>(x.Result);
            });

            return result;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProductResponce>> Get(string controller)
        {
            IEnumerable<ProductResponce> result = null;

            var client = _clientFactory.CreateClient("ecoproduce").AddJwt(_token);
            string path = $"api/{controller}";
            var response = await client.GetAsync(path);

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<IEnumerable<ProductResponce>>(x.Result);
            });

            return result;
        }

        [HttpPost]
        public async Task<ProductResponce> Post(U postObject, string controller, string id)
        {
            ProductResponce result = null;

            var client = _clientFactory.CreateClient("ecoproduce").AddJwt(_token);

            HttpResponseMessage response;
            if (postObject.GetType().Name == "ProductPostRequest")
            {
                var multiContent = new MultipartFormDataContent {
                    {new StringContent(JsonConvert.SerializeObject(postObject), System.Text.Encoding.UTF8, "multipart/form-data")}
                };
                //client.DefaultRequestHeaders.Remove("ContentType");
                //client.DefaultRequestHeaders.Add("ContentType", "multipart/form-data");
                //multiContent.Add(new StringContent(JsonConvert.SerializeObject(postObject), System.Text.Encoding.UTF8, "multipart/form-data")); 
                string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
                response = await client.PostAsync(path, multiContent).ConfigureAwait(false);
            }
            else
            {
                var content = new StringContent(JsonConvert.SerializeObject(postObject), System.Text.Encoding.UTF8, "application/json");
                string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
                response = await client.PostAsync(path, content).ConfigureAwait(false);
            }
            
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<ProductResponce>(x.Result);
            });

            return result;
        }

        [HttpPost]
        public async Task<ProductResponse> Post(IFormFile file, string controller, string id)
        {
            ProductResponse result = null;
            var client = _clientFactory.CreateClient("ecoproduce").AddJwt(_token);

            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
                data = br.ReadBytes((int)file.OpenReadStream().Length);
            ByteArrayContent bytes = new ByteArrayContent(data);

            HttpResponseMessage response;

            var multiContent = new MultipartFormDataContent();
                
            multiContent.Add(bytes, "file", file.FileName);
            string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
            response = await client.PostAsync(path, multiContent).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<ProductResponse>(x.Result);
            });

            return result;
        }

        /*[HttpPost]
        public async Task<ProductResponce> Post(ProductPostRequest postObject, string controller, string id)
        {
            ProductResponce result = null;

            var client = _clientFactory.CreateClient("ecoproduce").AddJwt(_token);
            byte[] data;
            using (var br = new BinaryReader(postObject.IFormFile.OpenReadStream()))
                data = br.ReadBytes((int)postObject.IFormFile.OpenReadStream().Length);
            ByteArrayContent bytes = new ByteArrayContent(data); 

            var multiContent = new MultipartFormDataContent();

            multiContent.Add(bytes);
            multiContent.Add(new StringContent(JsonConvert.SerializeObject(postObject.ProductRequest), System.Text.Encoding.UTF8));
            string path = id != null ? $"api/{controller}/{id}" : $"api/{controller}";
            var response = await client.PostAsync(path, multiContent).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();



            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<ProductResponce>(x.Result);
            });

            return result;
        }*/

        [HttpPut]
        public async Task<ProductResponce> Put(U putObject, string controller)
        {
            ProductResponce result = null;

            var client = _clientFactory.CreateClient("ecoproduce").AddJwt(_token);
            var content = new StringContent(JsonConvert.SerializeObject(putObject), System.Text.Encoding.UTF8, "application/json");
            string path = $"api/{controller}";
            var response = await client.PutAsync(path, content).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<ProductResponce>(x.Result);
            });

            return result;
        }

        [HttpDelete]
        public async Task<ProductResponce> Delete(string controller, string id)
        {
            ProductResponce result = null;

            var client = _clientFactory.CreateClient("ecoproduce").AddJwt(_token);
            string path = $"api/{controller}/{id}";
            var response = await client.DeleteAsync(path).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<ProductResponce>(x.Result);
            });

            return result;
        }
    }
}

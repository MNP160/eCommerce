using eCommerceFrontend.Models.REST.Objects.Stripe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceFrontend.Controllers
{
    public class PaymentController :Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;
        public PaymentController(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor )
        {
            _clientFactory =clientFactory;
            _contextAccessor = contextAccessor;

        }

        [HttpPost]
        public async Task<IActionResult> Processing(string stripeEmail, string stripeToken)
        {
             StripeResponce stripeObject = new StripeResponce(stripeEmail, stripeToken);

             System.Diagnostics.Debug.WriteLine(" "+stripeObject.stripeEmail+" "+ stripeObject.stripeToken);
            var client= _clientFactory.CreateClient();
            // var serialized = JsonConvert.SerializeObject(stripeObject);
             var content = new StringContent(JsonConvert.SerializeObject(stripeObject), System.Text.Encoding.UTF8, "application/json");
             string path = "https://localhost:44326/api/payment/charge";

           //  var wtf = JsonConvert.DeserializeObject<StripeResponce>(serialized);
             //System.Diagnostics.Debug.WriteLine(" " + wtf.Email + " " + wtf.Token);
            
             var response= await client.PostAsync(path, content);
             // response.EnsureSuccessStatusCode();

             var transactionId= await response.Content.ReadAsStringAsync();

             ViewBag.TransactionId = transactionId.ToString();

          
         
            return View();
        }
    }

    }


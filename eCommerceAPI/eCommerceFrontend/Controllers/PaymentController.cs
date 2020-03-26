using eCommerceFrontend.Models.REST.Objects.Stripe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


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

            
            var client= _clientFactory.CreateClient();
          
             var content = new StringContent(JsonConvert.SerializeObject(stripeObject), System.Text.Encoding.UTF8, "application/json");
             string path = "http://ecoproduce.eu/api/payment/charge";

           
            
             var response= await client.PostAsync(path, content);
             

             var transactionId= await response.Content.ReadAsStringAsync();

             ViewBag.TransactionId = transactionId.ToString();

          
         
            return View();
        }
    }

    }


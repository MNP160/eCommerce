using eCommerceAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController :ControllerBase
    {

        [HttpPost("charge")]
        public IActionResult Charge(StripeModel model)
        {
                       
          
            Dictionary<string, string> Metadata = new Dictionary<string, string>();
            Metadata.Add("superduperProduct", "with id 1");
            Metadata.Add("Quantity", "2");
            var options = new ChargeCreateOptions
            {
                Amount = 5000,
                Currency = "USD",
                Description = "testing",
                Source = model.stripeToken,
                ReceiptEmail = model.stripeEmail,
                Metadata = Metadata
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);
            
            return Ok(charge.BalanceTransactionId);
           
        }

    }
}

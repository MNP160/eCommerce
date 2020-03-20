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
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {

            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions { 
                Email=stripeEmail,
                Source=stripeToken

            });

            var charge = charges.Create(new ChargeCreateOptions { 
                Amount=500,   //change this to product price later
                Description="changeThisToSomethingMeaningfulLater",
                Currency="bgn",
                Customer=customer.Id,
                //here I can add whatever data i need for database
                Metadata=new Dictionary<string, string>()
                {
                    { "OrderId","123454"},
                    { "UserId", "1" }
                }

            });

            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                //this should be the transactionId
                //we can use this to maybe integrate with our users
                //for now like this for test

                return Ok(BalanceTransactionId);
            }

            return Ok();
        }

    }
}

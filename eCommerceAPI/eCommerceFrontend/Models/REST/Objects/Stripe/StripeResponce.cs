using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.REST.Objects.Stripe
{
    public class StripeResponce
    {

        public string stripeEmail;
        public string stripeToken;

        public StripeResponce(string email, string token)
        {
            stripeEmail = email;
            stripeToken = token;
        }

        
    }
}

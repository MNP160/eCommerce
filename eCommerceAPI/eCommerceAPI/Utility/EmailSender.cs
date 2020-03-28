using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Utility
{
    public class EmailSender
    {
        public string Sender { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string SMTPClient { get; set; }

    }
}

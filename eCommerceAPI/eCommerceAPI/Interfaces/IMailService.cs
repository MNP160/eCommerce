using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Interfaces
{
    public interface IMailService
    {
        abstract void SendEmail(string ReceiverEmail, string Username, string subject, string MessageBody);


    }
}

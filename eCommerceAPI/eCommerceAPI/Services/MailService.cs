using eCommerceAPI.Interfaces;
using eCommerceAPI.Utility;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace eCommerceAPI.Services
{
    public class MailService : IMailService
    {
        private readonly EmailSender _sender;

        public MailService(IOptions<EmailSender> sender)
        {
            _sender = sender.Value;
        }



        public void SendEmail(string ReceiverEmail, string username, string subject, string MessageBody)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(ReceiverEmail, "Dearest "+username));
                message.From = new MailAddress(_sender.Sender, "Best Shopping Platform Ever");

                message.Subject = subject;
                message.Body = MessageBody;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient(_sender.SMTPClient))
                {
                    client.Port = _sender.Port;
                    client.Credentials = new NetworkCredential(_sender.Sender, _sender.Password);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }


        }


    }
}

using BfkPortal.Web.Contracts;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BfkPortal.Web.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient client;

        public EmailService()
        {
            client = new SmtpClient()
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com"
            };
        }

        public async Task Send(string to, string from, string subject, string content)
        {
            var mail = new MailMessage(from, to)
            {
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };

            await client.SendMailAsync(mail);
        }

        public async Task Send(string[] to, string from, string subject, string content)
        {
            var mail = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };
            foreach (var email in to)
                mail.To.Add(email);

            await client.SendMailAsync(mail);
        }
    }
}

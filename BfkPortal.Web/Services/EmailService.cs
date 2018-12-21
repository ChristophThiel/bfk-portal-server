using BfkPortal.Web.Contracts;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BfkPortal.Web.Services
{
    public class EmailService : IEmailService
    {
        // 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
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
            /*var mail = new MailMessage(from, to)
            {
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };

            await client.SendMailAsync(mail);*/
            var client = new SendGridClient(Environment.GetEnvironmentVariable(Constants.SendGridApiKey));
            var email = MailHelper.CreateSingleEmail(new EmailAddress(from), new EmailAddress(to), subject, "", content);

            var response = await client.SendEmailAsync(email);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"An error occured during sending the email to {to}.");
        }

        public async Task Send(string[] to, string from, string subject, string content)
        {
            /*var mail = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };
            foreach (var email in to)
                mail.To.Add(email);

            await client.SendMailAsync(mail);*/
            var client = new SendGridClient(Environment.GetEnvironmentVariable(Constants.SendGridApiKey));
            var email = MailHelper.CreateSingleEmailToMultipleRecipients(new EmailAddress(from),
                to.Select(e => new EmailAddress(e)).ToList(), subject, "", content);

            var response = await client.SendEmailAsync(email);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"An error occured during sending the email to {to}.");
        }
    }
}

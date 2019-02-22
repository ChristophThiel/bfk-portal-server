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
        public async Task Send(string to, string from, string subject, string content)
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable(Constants.SendGridApiKey));
            var email = MailHelper.CreateSingleEmail(new EmailAddress(from), new EmailAddress(to), subject, "", content);

            var response = await client.SendEmailAsync(email);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"An error occured during sending the email to {to}.");
        }

        public async Task Send(string[] to, string from, string subject, string content)
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable(Constants.SendGridApiKey));
            var email = MailHelper.CreateSingleEmailToMultipleRecipients(new EmailAddress(from),
                to.Select(e => new EmailAddress(e)).ToList(), subject, "", content);

            var response = await client.SendEmailAsync(email);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"An error occured during sending the email to {to}.");
        }
    }
}

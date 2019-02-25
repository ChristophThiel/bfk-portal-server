using BfkPortal.Web.Contracts;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace BfkPortal.Web.Services
{
    public class EmailService : IEmailService
    {
        public async Task Send(string to, string subject, string content)
        {
            var client = new SendGridClient(System.Environment.GetEnvironmentVariable(Constants.SendGridApiKey));
            var mail = MailHelper.CreateSingleEmail(new EmailAddress(Constants.SendGridMail), new EmailAddress(to), subject, "", content);
            var response = await client.SendEmailAsync(mail);
        }
    }
}

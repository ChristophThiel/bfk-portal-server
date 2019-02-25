using BfkPortal.Web.Contracts;
using System;
using System.Threading.Tasks;

namespace BfkPortal.Web.Services
{
    public class EmailService : IEmailService
    {
        public async Task Send(string to, string from, string subject, string content)
        {
            throw new NotImplementedException();
        }

        public async Task Send(string[] to, string from, string subject, string content)
        {
            throw new NotImplementedException();
        }
    }
}

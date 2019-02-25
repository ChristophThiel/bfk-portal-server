using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IEmailService
    {
        Task Send(string to, string subject, string content);
    }
}

using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BfkPortal.Services
{
    public class DefaultMailService
    {
        private const string From = "bfk.portal@gmail.com";
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587;

        public static bool SendUserAddMessage(string email, string firstname, string lastname, string password, string path)
        {
            var document = File.ReadAllText(Path.Combine(path, "user-registration.html"))
                .Replace(nameof(email), email)
                .Replace(nameof(password), password);

            return Send(email, "Neuer Account", document);
        }

        private static bool Send(string to, string subject, string message)
        {
            try
            {
                var mail = new MailMessage(From, to, subject, message) {IsBodyHtml = true};
                var client = new SmtpClient
                {
                    Host = SmtpHost,
                    Port = SmtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(From, @"{rCA4*k&QdF\thr(")
                };
                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

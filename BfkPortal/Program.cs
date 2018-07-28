using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BfkPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://localhost:4000")
                .UseStartup<Startup>()
                .Build();
    }
}

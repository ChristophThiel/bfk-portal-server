using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BfkPortal.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), Constants.WwwRoot, Constants.Dist))
                .UseKestrel()
                .UseUrls("http://localhost:4000")
                .UseStartup<Startup>()
                .Build();
    }
}

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net;

namespace BfkPortal.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Build().Run();
        }

        public static IWebHostBuilder BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 4000, listenOptions =>
                    {
                        listenOptions.UseHttps();
                    });
                })
                .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), Constants.WwwRoot, Constants.Dist))
                .UseStartup<Startup>();
    }
}

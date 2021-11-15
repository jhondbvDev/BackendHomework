using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using static BackendHomework.Infrastructure.Extensions.HostExtensions;

namespace BackendHomework.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().SeedData().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

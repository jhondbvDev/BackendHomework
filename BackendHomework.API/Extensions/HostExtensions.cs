using BackendHomework.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackendHomework.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<BackendHomeworkDbContext>();

                context.Database.EnsureCreated();
                new DataSeeder(context).SeedData();  
            }

            return host;
        }
    }
}

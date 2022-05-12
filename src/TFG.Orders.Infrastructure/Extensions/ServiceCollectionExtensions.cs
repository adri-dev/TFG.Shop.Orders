using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TFG.Orders.Application.Abstractions.Repositories;
using TFG.Orders.Infrastructure.Persistance.Contexts;
using TFG.Orders.Infrastructure.Persistance.Repositories;

namespace TFG.Orders.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<OrdersDbContext>(o =>
                o.UseSqlServer(configuration.GetConnectionString("OrdersDb")))
                .AddScoped<IOrderReadOnlyRepository, OrderRepository>()
                .AddScoped<IOrderRepository, OrderRepository>();
        }

        public static void ApplyMigrations(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<OrdersDbContext>();
                context.Database.Migrate();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TFG.Orders.Infrastructure.Persistance.Contexts;

namespace TFG.Orders.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<OrdersDbContext>(o =>
                o.UseSqlServer(configuration.GetConnectionString("OrdersDb")));
        }
    }
}

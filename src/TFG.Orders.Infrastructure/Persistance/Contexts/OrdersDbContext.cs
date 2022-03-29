using Microsoft.EntityFrameworkCore;
using TFG.Orders.Domain.Entities;

namespace TFG.Orders.Infrastructure.Persistance.Contexts
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}

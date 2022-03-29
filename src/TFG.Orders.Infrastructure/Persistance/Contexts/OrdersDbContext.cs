using Microsoft.EntityFrameworkCore;
using TFG.Orders.Domain.Entities;

namespace TFG.Orders.Infrastructure.Persistance.Contexts
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrdersDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);
        }

    }
}

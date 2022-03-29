using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.Orders.Domain.Entities;

namespace TFG.Orders.Infrastructure.Persistance.EntitiesConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsMany(x => x.Lines, b =>
            {
                b.HasKey(l => l.Id);
                b.Property(l => l.ProductId).IsRequired();
                b.Property(l => l.ProductQuantity).IsRequired();
            });
        }
    }
}

using TFG.Orders.Domain.Entities;

namespace TFG.Orders.Application.Abstractions.Repositories
{
    public interface IOrderRepository : IOrderReadOnlyRepository
    {
        public Task AddAsync(Order order);
        public Task SaveChangesAsync();
    }
}

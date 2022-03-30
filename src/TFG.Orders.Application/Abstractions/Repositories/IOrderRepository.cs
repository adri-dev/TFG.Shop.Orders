using TFG.Orders.Domain.Entities;

namespace TFG.Orders.Application.Abstractions.Repositories
{
    public interface IOrderRepository : IOrderReadOnlyRepository
    {
        Task AddAsync(Order order);
        Task SaveChangesAsync();
    }
}

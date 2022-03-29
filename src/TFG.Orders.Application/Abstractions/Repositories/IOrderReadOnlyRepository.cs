using System.Linq.Expressions;
using TFG.Orders.Domain.Entities;

namespace TFG.Orders.Application.Abstractions.Repositories
{
    public interface IOrderReadOnlyRepository
    {
        Task<Order?> FirstOrDefaultAsync(Expression<Func<Order, bool>> expression);
        Task<IList<Order>> AllAsync();
    }
}

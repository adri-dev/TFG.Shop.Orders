using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TFG.Orders.Application.Abstractions.Repositories;
using TFG.Orders.Domain.Entities;
using TFG.Orders.Infrastructure.Persistance.Contexts;

namespace TFG.Orders.Infrastructure.Persistance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersDbContext _ordersDbContext;

        public OrderRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public async Task AddAsync(Order order)
        {
            await _ordersDbContext.AddAsync(order);
        }

        public async Task<IList<Order>> AllAsync()
        {
            return await _ordersDbContext
                .Orders
                .Include(o => o.Lines)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order?> FirstOrDefaultAsync(Expression<Func<Order, bool>> expression)
        {
            return await _ordersDbContext
                .Orders
                .Include(o => o.Lines)
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);
        }

        public async Task SaveChangesAsync()
        {
            await _ordersDbContext.SaveChangesAsync();
        }
    }
}

using MediatR;
using TFG.Orders.Application.Abstractions.Repositories;
using TFG.Orders.Domain.Entities;

namespace TFG.Orders.Application.Commands.CreateOrder
{
    public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest, int>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new Order();

            request.Lines.ToList().ForEach(line =>
            {
                order.AddLine(line.productId, line.quantity);
            });

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}

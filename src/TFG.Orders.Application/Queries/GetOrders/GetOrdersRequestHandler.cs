using MediatR;
using TFG.Orders.Application.Abstractions.Repositories;

namespace TFG.Orders.Application.Queries.GetOrders
{
    public class GetOrdersRequestHandler : IRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        private readonly IOrderReadOnlyRepository _repository;

        public GetOrdersRequestHandler(IOrderReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var orders = await _repository.AllAsync();

            var response = new GetOrdersResponse();
            foreach (var order in orders)
            {
                var orderResponse = new OrderEntry(order.Id);
                orderResponse.Lines = orderResponse.Lines.Select(l => new OrderEntry.OrderLine(l.Id, l.productId, l.quantity));
            }

            return response;
        }
    }
}

using MediatR;
using TFG.Orders.Application.Abstractions.Repositories;

namespace TFG.Orders.Application.Queries.GetOrder
{
    public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, GetOrderResponse>
    {
        private readonly IOrderReadOnlyRepository _repository;

        public GetOrderRequestHandler(IOrderReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderResponse> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _repository.FirstOrDefaultAsync(o => o.Id == request.orderId);

            if (order == null)
                return null;

            var response = new GetOrderResponse(order.Id);
            response.Lines = order.Lines.Select(line => new GetOrderResponse.OrderLine(line.Id, line.ProductId, line.ProductQuantity));

            return response;
        }
    }
}

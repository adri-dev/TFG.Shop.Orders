using MediatR;

namespace TFG.Orders.Application.Queries.GetOrder
{
    public record GetOrderRequest(int orderId) : IRequest<GetOrderResponse>;
}
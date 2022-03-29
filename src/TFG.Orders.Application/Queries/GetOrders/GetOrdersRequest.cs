using MediatR;

namespace TFG.Orders.Application.Queries.GetOrders
{
    public record GetOrdersRequest() : IRequest<GetOrdersResponse>;
}

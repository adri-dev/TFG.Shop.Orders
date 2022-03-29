using MediatR;

namespace TFG.Orders.Application.Commands.CreateOrder
{
    public class CreateOrderRequest : IRequest<int>
    {
        public record CreateOrderLine(int productId, decimal quantity);

        public IEnumerable<CreateOrderLine> Lines { get; set; }

        public CreateOrderRequest()
        {
            Lines = new List<CreateOrderLine>();
        }
    }
}

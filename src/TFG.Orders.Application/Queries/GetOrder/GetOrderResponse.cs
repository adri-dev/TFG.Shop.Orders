namespace TFG.Orders.Application.Queries.GetOrder
{
    public class GetOrderResponse
    {
        public record OrderLine(int Id, int productId, decimal quantity);

        public IEnumerable<OrderLine> Lines { get; set; }

        public GetOrderResponse(int id)
        {
            Lines = new List<OrderLine>();
        }
    }
}

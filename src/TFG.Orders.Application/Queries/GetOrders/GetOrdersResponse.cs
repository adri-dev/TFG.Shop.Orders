using System.Collections;

namespace TFG.Orders.Application.Queries.GetOrders
{
    public class OrderEntry
    {
        public record OrderLine(int Id, int ProductId, decimal Quantity);

        public IEnumerable<OrderLine> Lines { get; set; }

        public int Id { get; set; }

        public OrderEntry(int id)
        {
            Id = id;
            Lines = new List<OrderLine>();
        }
    }

    public class GetOrdersResponse : IEnumerable<OrderEntry>
    {
        private readonly List<OrderEntry> _orders;

        public GetOrdersResponse()
        {
            _orders = new List<OrderEntry>();
        }

        public void Add(OrderEntry order)
            => _orders.Add(order);

        public IEnumerator<OrderEntry> GetEnumerator()
            => _orders.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}

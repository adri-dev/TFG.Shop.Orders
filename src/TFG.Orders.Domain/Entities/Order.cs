namespace TFG.Orders.Domain.Entities
{
    public class Order : BaseEntity
    {
        private List<OrderLine> _lines;

        public IReadOnlyList<OrderLine> Lines => _lines;

        public Order()
        {
            _lines = new List<OrderLine>();
        }
    }
}

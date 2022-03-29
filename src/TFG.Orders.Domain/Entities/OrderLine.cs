namespace TFG.Orders.Domain.Entities
{
    public class OrderLine : BaseEntity
    {
        public int ProductId { get; private set; }
        public decimal ProductQuantity { get; private set; }


        public OrderLine(int productId, decimal productQuantity)
        {
            ProductId = productId;
            ProductQuantity = productQuantity;
        }
    }
}

using FluentValidation;

namespace TFG.Orders.Application.Commands.CreateOrder
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(r => r).NotNull();
            RuleFor(r => r.Lines).NotEmpty();
            RuleForEach(r => r.Lines)
                .ChildRules(rb =>
                {
                    rb.RuleFor(l => l.productId).GreaterThan(0);
                    rb.RuleFor(l => l.quantity).GreaterThan(0);
                });
        }
    }
}

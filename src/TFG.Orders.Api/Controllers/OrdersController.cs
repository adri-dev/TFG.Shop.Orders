using MediatR;
using Microsoft.AspNetCore.Mvc;
using TFG.Orders.Application.Commands.CreateOrder;
using TFG.Orders.Application.Queries.GetOrder;
using TFG.Orders.Application.Queries.GetOrders;

namespace TFG.Orders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult> GetOrder(int orderId)
        {
            var response = await _mediator.Send(new GetOrderRequest(orderId));

            return response != null ? Ok(response) : NotFound();
        }


        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            var response = await _mediator.Send(new GetOrdersRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRequest(CreateOrderRequest request)
        {
            var result = await _mediator.Send(request);

            return Created("", new { Id = result});
        }
    }
}
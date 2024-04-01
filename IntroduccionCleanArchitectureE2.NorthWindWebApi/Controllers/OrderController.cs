using IntroduccionCleanArchitectureE2.NorthWindUseCases.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionCleanArchitectureE2.NorthWindWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-order")]

        public async Task<ActionResult<int>> CreateOrder(CreateOrderInputPort createOrderInputPort)
        {
            return await _mediator.Send(createOrderInputPort);
        }
    }
}

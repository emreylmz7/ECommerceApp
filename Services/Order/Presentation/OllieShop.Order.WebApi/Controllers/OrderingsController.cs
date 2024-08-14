using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using OllieShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace OllieShop.Order.WebApi.Controllers
{
    [AllowAnonymous]

    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList() 
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdering(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("GetOrderingsByUser")]
        public async Task<IActionResult> GetOrderingsByUser()
        {
            var value = await _mediator.Send(new GetOrderingsByUserQuery());
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering Created Succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(RemoveOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering Deleted Succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering Updated Succesfully");
        }

        [HttpGet("GetOrderStatistics")]
        public async Task<IActionResult> GetOrderStatistics()
        {
            var value = await _mediator.Send(new GetOrderingStatisticsQuery());
            return Ok(value);
        }
    }
}

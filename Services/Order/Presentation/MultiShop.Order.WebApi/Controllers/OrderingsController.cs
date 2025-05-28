using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderingsController : ControllerBase
{
    #region Fields

    private readonly IMediator _mediator;

    #endregion

    #region Ctor

    public OrderingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetOrderingList()
    {
        var orderings = await _mediator.Send(new GetOrderingQuery());

        return Ok(orderings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderingById(int id)
    {
        var ordering = await _mediator.Send(new GetOrderingByIdQuery(id));

        return Ok(ordering);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
    {
        await _mediator.Send(createOrderingCommand);

        return Ok("Sipariş başarıyla eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
    {
        await _mediator.Send(updateOrderingCommand);

        return Ok("Sipariş başarıyla güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrdering(int id)
    {
        await _mediator.Send(new RemoveOrderingCommand(id));

        return Ok("Sipariş başarıyla silindi");
    }

    #endregion
}

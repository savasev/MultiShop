using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    #region Fields

    private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
    private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
    private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
    private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;
    private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;

    #endregion

    #region Ctor

    public OrderDetailsController(CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
        GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
        GetOrderDetailQueryHandler getOrderDetailQueryHandler,
        RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler,
        UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
    {
        _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
        _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
        _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
        _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetOrderDetailList()
    {
        var orderDetails = await _getOrderDetailQueryHandler.Handle();

        return Ok(orderDetails);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        var orderDetail = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));

        return Ok(orderDetail);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
    {
        await _createOrderDetailCommandHandler.Handle(createOrderDetailCommand);

        return Ok("Sipariş detayı başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
    {
        await _updateOrderDetailCommandHandler.Handle(updateOrderDetailCommand);

        return Ok("Sipariş detayı başarıyla güncellendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));

        return Ok("Sipariş detayı başarıyla silindi");
    }

    #endregion
}

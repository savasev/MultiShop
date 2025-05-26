using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;

namespace MultiShop.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
	#region Fields

	private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
	private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
	private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
	private readonly RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler;
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
        this.removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
    }

    #endregion

    #region Methods



    #endregion
}

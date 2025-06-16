using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;

public class UpdateOrderDetailCommandHandler
{
    #region Fields

    private readonly IRepository<OrderDetail> _orderDetailRepository;

    #endregion

    #region Ctor

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    #endregion

    #region Methods

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(command.OrderDetailId);

        orderDetail.OrderingId = command.OrderingId;
        orderDetail.ProductId = command.ProductId;
        orderDetail.ProductAmount = command.ProductAmount;
        orderDetail.ProductName = command.ProductName;
        orderDetail.ProductPrice = command.ProductPrice;
        orderDetail.ProductTotalPrice = command.ProductTotalPrice;

        await _orderDetailRepository.UpdateAsync(orderDetail);
    }

    #endregion
}

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
        await _orderDetailRepository.UpdateAsync(new OrderDetail
        {
            OrderDetailId = command.OrderDetailId,
            OrderingId = command.OrderingId,
            ProductId = command.ProductId,
            ProductAmount = command.ProductAmount,
            ProductName = command.ProductName,
            ProductPrice = command.ProductPrice,
            ProductTotalPrice = command.ProductTotalPrice,
        });
    }

    #endregion
}

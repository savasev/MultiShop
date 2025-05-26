using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;

public class RemoveOrderDetailCommandHandler
{
    #region Fields

    private readonly IRepository<OrderDetail> _orderDetailRepository;

    #endregion

    #region Ctor

    public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    #endregion

    #region Methods

    public async Task Handle(RemoveAddressCommand removeAddressCommand)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(removeAddressCommand.AddressId);

        await _orderDetailRepository.DeleteAsync(orderDetail);
    }

    #endregion
}

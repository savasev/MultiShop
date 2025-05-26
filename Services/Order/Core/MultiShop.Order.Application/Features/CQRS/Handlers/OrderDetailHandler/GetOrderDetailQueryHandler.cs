using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;

public class GetOrderDetailQueryHandler
{
    #region Fields

    private readonly IRepository<OrderDetail> _orderRepository;

    #endregion

    #region Ctor

    public GetOrderDetailQueryHandler(IRepository<OrderDetail> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    #endregion

    #region Methods

    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var orderDetails = await _orderRepository.GetAllAsync();

        return orderDetails.Select(x => new GetOrderDetailQueryResult
        {
            OrderDetailId = x.OrderDetailId,
            OrderingId = x.OrderingId,
            ProductAmount = x.ProductAmount,
            ProductId = x.ProductId,
            ProductName = x.ProductName,
            ProductPrice = x.ProductPrice,
            ProductTotalPrice = x.ProductTotalPrice,
        }).ToList();
    }

    #endregion
}

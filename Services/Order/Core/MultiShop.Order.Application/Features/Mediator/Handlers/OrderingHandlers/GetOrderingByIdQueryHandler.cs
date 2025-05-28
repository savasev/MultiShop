using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    #region Fields

    private readonly IRepository<Ordering> _orderingRepository;

    #endregion

    #region Ctor

    public GetOrderingByIdQueryHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    #endregion

    #region Methods

    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var ordering = await _orderingRepository.GetByIdAsync(request.Id);

        return new GetOrderingByIdQueryResult
        {
            OrderingId = ordering.OrderingId,
            OrderDate = ordering.OrderDate,
            TotalPrice = ordering.TotalPrice,
            UserId = ordering.UserId,
        };
    }

    #endregion
}

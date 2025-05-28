using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    #region Fields

    private readonly IRepository<Ordering> _orderingRepository;

    #endregion

    #region Ctor

    public GetOrderingQueryHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    #endregion

    #region Methods

    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var orderings = await _orderingRepository.GetAllAsync();

        return orderings.Select(x => new GetOrderingQueryResult
        {
            OrderingId = x.OrderingId,
            OrderDate = x.OrderDate,
            TotalPrice = x.TotalPrice,
            UserId = x.UserId,
        }).ToList();
    }

    #endregion
}

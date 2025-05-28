using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
{
    #region Fields

    private readonly IRepository<Ordering> _orderingRepository;

    #endregion

    #region Ctor

    public RemoveOrderingCommandHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    #endregion

    #region Methods

    public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        var ordering = await _orderingRepository.GetByIdAsync(request.OrderingId);

        await _orderingRepository.DeleteAsync(ordering);
    }

    #endregion
}

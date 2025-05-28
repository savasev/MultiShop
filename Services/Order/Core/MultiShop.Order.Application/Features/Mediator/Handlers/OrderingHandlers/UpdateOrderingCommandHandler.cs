using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    #region Fields

    private readonly IRepository<Ordering> _orderingRepository;

    #endregion

    #region Ctor

    public UpdateOrderingCommandHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    #endregion

    #region Methods

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var ordering = await _orderingRepository.GetByIdAsync(request.OrderingId);

        ordering.OrderDate = request.OrderDate;
        ordering.UserId = request.UserId;
        ordering.TotalPrice = request.TotalPrice;

        await _orderingRepository.UpdateAsync(ordering);
    }

    #endregion
}

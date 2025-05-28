using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
{
    #region Fields

    private readonly IRepository<Ordering> _orderingRepository;

    #endregion

    #region Ctor

    public CreateOrderingCommandHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    #endregion

    #region Methods

    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _orderingRepository.CreateAsync(new Ordering
        {
            OrderDate = request.OrderDate,
            TotalPrice = request.TotalPrice,
            UserId = request.UserId,
        });
    }

    #endregion
}

using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler
{
    #region Fields

    private readonly IRepository<Address> _addressRepository;

    #endregion

    #region Ctor

    public CreateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    #endregion

    #region Methods

    public async Task Handle(CreateAddressCommand createAddressCommand)
    {
        await _addressRepository.CreateAsync(new Address
        {
            City = createAddressCommand.City,
            District = createAddressCommand.District,
            Detail = createAddressCommand.Detail,
            UserId = createAddressCommand.UserId,
        });
    }

    #endregion
}

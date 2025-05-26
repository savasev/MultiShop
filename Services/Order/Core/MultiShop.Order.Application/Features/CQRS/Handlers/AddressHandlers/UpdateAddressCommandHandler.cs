using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    #region Fields

    private readonly IRepository<Address> _addressRepository;

    #endregion

    #region Ctor

    public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    #endregion

    #region Methods

    public async Task Handle(UpdateAddressCommand command)
    {
        var address = await _addressRepository.GetByIdAsync(command.AddressId);

        address.Detail = command.Detail;
        address.City = command.City;
        address.District = command.District;
        address.UserId = command.UserId;

        await _addressRepository.UpdateAsync(address);
    }

    #endregion
}

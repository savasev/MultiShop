using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressCommandHandler
{
    #region Fields

    private readonly IRepository<Address> _addressRepository;

    #endregion

    #region Ctor

    public RemoveAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    #endregion

    #region Methods

    public async Task Handle(RemoveAddressCommand removeAddressCommand)
    {
        var address = await _addressRepository.GetByIdAsync(removeAddressCommand.AddressId);

        await _addressRepository.DeleteAsync(address);
    }

    #endregion
}

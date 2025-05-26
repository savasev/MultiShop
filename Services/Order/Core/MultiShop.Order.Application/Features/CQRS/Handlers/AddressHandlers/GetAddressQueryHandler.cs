using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler
{
    #region Fields

    private readonly IRepository<Address> _addressRepository;

    #endregion

    #region Ctor

    public GetAddressQueryHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    #endregion

    #region Methods

    public async Task<List<GetAddressQueryResult>> Handle()
    {
        var addresses = await _addressRepository.GetAllAsync();

        return addresses.Select(x => new GetAddressQueryResult
        {
            AddressId = x.AddressId,
            City = x.City,
            Detail = x.Detail,
            District = x.District,
            UserId = x.UserId,
        }).ToList();
    }

    #endregion
}

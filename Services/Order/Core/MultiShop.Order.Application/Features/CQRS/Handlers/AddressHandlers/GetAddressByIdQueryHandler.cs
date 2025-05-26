using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    #region Fields

    private readonly IRepository<Address> _addressRepository;

    #endregion

    #region Ctor

    public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    #endregion

    #region Methods

    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
    {
        var address = await _addressRepository.GetByIdAsync(query.Id);

        return new GetAddressByIdQueryResult
        {
            AddressId = address.AddressId,
            City = address.City,
            Detail = address.Detail,
            District = address.District,
            UserId = address.UserId,
        };
    }

    #endregion
}

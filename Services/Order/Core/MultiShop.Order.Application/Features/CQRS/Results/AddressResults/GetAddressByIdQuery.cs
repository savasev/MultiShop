namespace MultiShop.Order.Application.Features.CQRS.Results.AddressResults;

public class GetAddressByIdQuery
{
    public int Id { get; set; }

    public GetAddressByIdQuery(int id)
    {
        Id = id;
    }
}

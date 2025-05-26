namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;

public class RemoveAddressCommand
{
    public int AddressId { get; set; }

    public RemoveAddressCommand(int id)
    {
        AddressId = id;
    }
}

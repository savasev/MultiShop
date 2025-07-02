using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    #region Fields

    private readonly CreateAddressCommandHandler _createAddressCommandHandler;
    private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
    private readonly GetAddressQueryHandler _getAddressQueryHandler;
    private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
    private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;

    #endregion

    #region Ctor

    public AddressesController(CreateAddressCommandHandler createAddressCommandHandler,
        GetAddressByIdQueryHandler getAddressByIdQueryHandler,
        GetAddressQueryHandler getAddressQueryHandler,
        RemoveAddressCommandHandler removeAddressCommandHandler,
        UpdateAddressCommandHandler updateAddressCommandHandler)
    {
        _createAddressCommandHandler = createAddressCommandHandler;
        _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
        _getAddressQueryHandler = getAddressQueryHandler;
        _removeAddressCommandHandler = removeAddressCommandHandler;
        _updateAddressCommandHandler = updateAddressCommandHandler;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetAddressList()
    {
        var addresses = await _getAddressQueryHandler.Handle();

        return Ok(addresses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressListById(int id)
    {
        var address = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));

        return Ok(address);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
    {
        await _createAddressCommandHandler.Handle(createAddressCommand);

        return Ok("Adres bilgisi başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
    {
        await _updateAddressCommandHandler.Handle(updateAddressCommand);

        return Ok("Adres bilgisi başarıyla güncellendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));

        return Ok("Adres bilgisi başarıyla silindi.");
    }

    #endregion
}

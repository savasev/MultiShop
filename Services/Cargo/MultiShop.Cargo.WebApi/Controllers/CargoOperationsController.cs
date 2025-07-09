using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController : ControllerBase
{
    #region Fields

    private readonly ICargoOperationService _cargoOperationService;

    #endregion

    #region Ctor

    public CargoOperationsController(ICargoOperationService cargoOperationService)
    {
        _cargoOperationService = cargoOperationService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> CargoOperationList()
    {
        var cargoOperations = await _cargoOperationService.GetAllAsync();

        return Ok(cargoOperations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoOperationById(int id)
    {
        var cargoOperation = await _cargoOperationService.GetByIdAsync(id);

        return Ok(cargoOperation);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
    {
        await _cargoOperationService.InsertAsync(new CargoOperation
        {
            Barcode = createCargoOperationDto.Barcode,
            Description = createCargoOperationDto.Description,
            OperationDate = createCargoOperationDto.OperationDate,
        });

        return Ok("Kargo işlemi başarıyla oluşturuldu");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
    {
        await _cargoOperationService.UpdateAsync(new CargoOperation
        {
            CargoOperationId = updateCargoOperationDto.CargoOperationId,
            Barcode = updateCargoOperationDto.Barcode,
            Description = updateCargoOperationDto.Description,
            OperationDate = updateCargoOperationDto.OperationDate,
        });

        return Ok("Kargo işlemi başarıyla güncellendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCargoOperation(int id)
    {
        await _cargoOperationService.DeleteAsync(id);

        return Ok("Kargo işlemi başarıyla silindi");
    }

    #endregion
}

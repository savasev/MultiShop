using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController : ControllerBase
{
    #region Fields

    private readonly ICargoDetailService _cargoDetailService;

    #endregion

    #region Ctor

    public CargoDetailsController(ICargoDetailService cargoDetailService)
    {
        _cargoDetailService = cargoDetailService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> CargoDetailList()
    {
        var cargoDetails = await _cargoDetailService.GetAllAsync();

        return Ok(cargoDetails);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoDetailById(int id)
    {
        var cargoDetail = await _cargoDetailService.GetByIdAsync(id);

        return Ok(cargoDetail);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
    {
        await _cargoDetailService.InsertAsync(new CargoDetail
        {
            Barcode = createCargoDetailDto.Barcode,
            ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
            SenderCustomer = createCargoDetailDto.SenderCustomer,
            CargoCompanyId = createCargoDetailDto.CargoCompanyId,
        });

        return Ok("Kargo detayı başarıyla oluşturuldu");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
    {
        await _cargoDetailService.UpdateAsync(new CargoDetail
        {
            CargoDetailId = updateCargoDetailDto.CargoDetailId,
            Barcode = updateCargoDetailDto.Barcode,
            ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
            SenderCustomer = updateCargoDetailDto.SenderCustomer,
            CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
        });

        return Ok("Kargo detayı başarıyla güncellendi.");
    }

    public async Task<IActionResult> RemoveCargoDetail(int id)
    {
        await _cargoDetailService.DeleteAsync(id);

        return Ok("Kargo detayı başarıyla silindi");
    }

    #endregion
}

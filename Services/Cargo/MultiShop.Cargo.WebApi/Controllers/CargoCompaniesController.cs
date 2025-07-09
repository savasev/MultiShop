using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController : ControllerBase
{
    #region Fields

    private readonly ICargoCompanyService _cargoCompanyService;

    #endregion

    #region Ctor

    public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
    {
        _cargoCompanyService = cargoCompanyService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> CargoCompanyList()
    {
        var cargoCompanies = await _cargoCompanyService.GetAllAsync();

        return Ok(cargoCompanies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoCompanyById(int id)
    {
        var cargoCompany = await _cargoCompanyService.GetByIdAsync(id);

        return Ok(cargoCompany);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        await _cargoCompanyService.InsertAsync(new CargoCompany
        {
            CargoCompanyName = createCargoCompanyDto.CargoCompanyName,
        });

        return Ok("Kargo şirketi başarıyla oluşturuldu");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        await _cargoCompanyService.UpdateAsync(new CargoCompany
        {
            CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
            CargoCompanyName = updateCargoCompanyDto.CargoCompanyName,
        });

        return Ok("Kargo şirketi başarıyla güncellendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCargoCompany(int id)
    {
        await _cargoCompanyService.DeleteAsync(id);

        return Ok("Kargo şirketi başarıyla silindi");
    }

    #endregion
}

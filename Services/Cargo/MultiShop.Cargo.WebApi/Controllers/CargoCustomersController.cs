using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController : ControllerBase
{
    #region Fields

    private readonly ICargoCustomerService _cargoCustomerService;

    #endregion

    #region Ctor

    public CargoCustomersController(ICargoCustomerService cargoCustomerService)
    {
        _cargoCustomerService = cargoCustomerService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> CargoCustomerList()
    {
        var cargoCustomers = await _cargoCustomerService.GetAllAsync();

        return Ok(cargoCustomers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoCustomerById(int id)
    {
        var cargoCustomer = await _cargoCustomerService.GetByIdAsync(id);

        return Ok(cargoCustomer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        await _cargoCustomerService.InsertAsync(new CargoCustomer
        {
            Address = createCargoCustomerDto.Address,
            City = createCargoCustomerDto.City,
            District = createCargoCustomerDto.District,
            Email = createCargoCustomerDto.Email,
            Name = createCargoCustomerDto.Name,
            Phone = createCargoCustomerDto.Phone,
            Surname = createCargoCustomerDto.Surname,
        });

        return Ok("Kargo müşteri başarıyla oluşturuldu");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        await _cargoCustomerService.UpdateAsync(new CargoCustomer
        {
            CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
            Address = updateCargoCustomerDto.Address,
            City = updateCargoCustomerDto.City,
            District = updateCargoCustomerDto.District,
            Email = updateCargoCustomerDto.Email,
            Name = updateCargoCustomerDto.Name,
            Phone = updateCargoCustomerDto.Phone,
            Surname = updateCargoCustomerDto.Surname,
        });

        return Ok("Kargo müşteri başarıyla güncellendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCargoCustomer(int id)
    {
        await _cargoCustomerService.DeleteAsync(id);

        return Ok("Kargo müşteri başarıyla silindi");
    }

    #endregion
}

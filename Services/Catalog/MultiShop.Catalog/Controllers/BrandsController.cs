using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers;

public class BrandsController : BaseApiController
{
    #region Fields

    private readonly IBrandService _brandService;

    #endregion

    #region Ctor

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetBrandList()
    {
        var brands = await _brandService.GetAllBrandsAsync();

        return Ok(brands);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById(string id)
    {
        var brand = await _brandService.GetBrandByIdAsync(id);

        return Ok(brand);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
    {
        await _brandService.CreateBrandAsync(createBrandDto);

        return Ok("Marka başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        await _brandService.UpdateBrandAsync(updateBrandDto);

        return Ok("Marka başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrandAsync(id);

        return Ok("Marka başarıyla silindi.");
    }

    #endregion
}

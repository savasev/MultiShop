using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers;

public class ProductImagesController : BaseApiController
{
	#region Fields

	private readonly IProductImageService _productImageService;

    #endregion

    #region Ctor

    public ProductImagesController(IProductImageService productImageService)
    {
        _productImageService = productImageService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetProductImageList()
    {
        var productImages = await _productImageService.GetAllProductImagesAsync();

        return Ok(productImages);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var productImage = await _productImageService.GetProductImageByIdAsync(id);

        return Ok(productImage);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await _productImageService.CreateProductImageAsync(createProductImageDto);

        return Ok("Ürün görseli başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await _productImageService.UpdateProductImageAsync(updateProductImageDto);

        return Ok("Ürün görseli başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _productImageService.DeleteProductImageAsync(id);

        return Ok("Ürün görseli başarıyla silindi.");
    }

    #endregion
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
    #region Fields

    private readonly IProductDetailService _productDetailService;

    #endregion

    #region Ctor

    public ProductDetailsController(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetProductDetailList()
    {
        var productDetails = await _productDetailService.GetAllProductDetailsAsync();

        return Ok(productDetails);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var productDetail = await _productDetailService.GetProductDetailByIdAsync(id);

        return Ok(productDetail);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await _productDetailService.CreateProductDetailAsync(createProductDetailDto);

        return Ok("Ürün detayı başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);

        return Ok("Ürün detayı başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _productDetailService.DeleteProductDetailAsync(id);

        return Ok("Ürün detayı başarıyla silindi.");
    }

    #endregion
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers;

public class ProductsController : BaseApiController
{
    #region Fields

    private readonly IProductService _productService;

    #endregion

    #region Ctor

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetProductList()
    {
        var products = await _productService.GetAllProductsAsync();

        return Ok(products);
    }

    [HttpGet("productlistwithcategory")]
    public async Task<IActionResult> GetProductListWithCategory()
    {
        var productsWithCategory = await _productService.GetAllProductsWithCategoryAsync();

        return Ok(productsWithCategory);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        await _productService.CreateProductAsync(createProductDto);

        return Ok("Ürün başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        await _productService.UpdateProductAsync(updateProductDto);

        return Ok("Ürün başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);

        return Ok("Ürün başarıyla silindi.");
    }

    #endregion
}

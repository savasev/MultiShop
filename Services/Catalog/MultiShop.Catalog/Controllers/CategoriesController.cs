using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers;

public class CategoriesController : BaseApiController
{
    #region Fields

    private readonly ICategoryService _categoryService;

    #endregion

    #region Ctor

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetCategoryList()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        await _categoryService.CreateCategoryAsync(createCategoryDto);

        return Ok("Kategori başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        await _categoryService.UpdateCategoryAsync(updateCategoryDto);

        return Ok("Kategori başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);

        return Ok("Kategori başarıyla silindi.");
    }

    #endregion
}

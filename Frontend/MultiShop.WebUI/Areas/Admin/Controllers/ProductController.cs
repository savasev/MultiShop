using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class ProductController : BaseAdminController
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Utilities

    private async Task PrepareAvailableCategoriesAsync(IList<SelectListItem> items, string selectedValue = "")
    {
        if (items == null)
            throw new ArgumentNullException(nameof(items));

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7070/api/categories");

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            var categoryItems = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId,
                Selected = c.CategoryId == selectedValue
            }).ToList();

            ((List<SelectListItem>)items).AddRange(categoryItems);
        }

        items.Insert(0, new SelectListItem { Value = "", Text = "Select Category" });
    }

    #endregion

    #region Methods

    #region List

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProductList()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/products");

        if (!response.IsSuccessStatusCode)
            return Json(new { data = new List<ResultProductDto>() });

        var jsonData = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

        return Json(new { data = products });
    }

    [HttpPost]
    public async Task<IActionResult> ProductListWithCategory()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/products/productlistwithcategory");

        if (!response.IsSuccessStatusCode)
            return Json(new { data = new List<ResultProductWithCategoryDto>() });

        var jsonData = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);

        return Json(new { data = products });
    }

    #endregion

    #region Create

    public async Task<IActionResult> Create()
    {
        var createProductDto = new CreateProductDto();

        await PrepareAvailableCategoriesAsync(createProductDto.AvailableCategories);

        return View(createProductDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto createProductDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createProductDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync("https://localhost:7070/api/products", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        await PrepareAvailableCategoriesAsync(createProductDto.AvailableCategories);

        return View(createProductDto);
    }

    #endregion

    #region Edit

    public async Task<IActionResult> Edit(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7070/api/products/{id}");

        if (!response.IsSuccessStatusCode)
            return RedirectToAction("List");

        var jsonData = await response.Content.ReadAsStringAsync();
        var editProductDto = JsonConvert.DeserializeObject<EditProductDto>(jsonData);

        await PrepareAvailableCategoriesAsync(editProductDto.AvailableCategories, editProductDto.CategoryId);

        return View(editProductDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditProductDto editProductDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(editProductDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync("https://localhost:7070/api/products", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        var errorMessage = await responseMessage.Content.ReadAsStringAsync();
        ModelState.AddModelError("", errorMessage);

        await PrepareAvailableCategoriesAsync(editProductDto.AvailableCategories, editProductDto.CategoryId);

        return View(editProductDto);
    }

    #endregion

    #region Delete

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/products/{id}");

        if (responseMessage.IsSuccessStatusCode)
            return Json(new { success = true });

        return Json(new { success = false });
    }

    #endregion

    #endregion
}

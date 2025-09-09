using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class CategoryController : BaseAdminController
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Methods

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CategoryList()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/categories");

        if (!response.IsSuccessStatusCode)
            return Json(new { data = new List<ResultCategoryDto>() });

        var jsonData = await response.Content.ReadAsStringAsync();
        var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

        return Json(new { data = categories });
    }

    public IActionResult Create()
    {
        return View(new CreateCategoryDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCategoryDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync("https://localhost:7070/api/categories", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        return View(createCategoryDto);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"https://localhost:7070/api/categories/{id}");

        if (!response.IsSuccessStatusCode)
            return RedirectToAction("List");

        var jsonData = await response.Content.ReadAsStringAsync();
        var editCategoryDto = JsonConvert.DeserializeObject<EditCategoryDto>(jsonData);

        return View(editCategoryDto);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/categories/{id}");

        if (responseMessage.IsSuccessStatusCode)
            return Json(new { success = true });

        return Json(new { success = false });
    }

    #endregion
}

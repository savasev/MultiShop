using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

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
    [AllowAnonymous]
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

    #endregion
}

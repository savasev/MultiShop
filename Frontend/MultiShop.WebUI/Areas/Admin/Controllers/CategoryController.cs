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

    public async Task<IActionResult> List()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/categories");

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        }

        return View();
    }

    #endregion
}

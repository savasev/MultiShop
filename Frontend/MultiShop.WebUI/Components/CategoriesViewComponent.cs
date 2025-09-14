using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Components;

public class CategoriesViewComponent : ViewComponent
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public CategoriesViewComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/categories");

        if (!response.IsSuccessStatusCode)
            return Content(string.Empty);

        var jsonData = await response.Content.ReadAsStringAsync();
        var categories = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonData)
            ?? new List<CategoryModel>();

        return View(categories);
    }

    #endregion
}

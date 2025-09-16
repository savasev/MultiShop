using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Components;

public class BrandsViewComponent : ViewComponent
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public BrandsViewComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/brands");

        if (!response.IsSuccessStatusCode)
            return Content(string.Empty);

        var jsonData = await response.Content.ReadAsStringAsync();
        var brands = JsonConvert.DeserializeObject<List<BrandModel>>(jsonData)
            ?? new List<BrandModel>();

        return View(brands);
    }

    #endregion
}

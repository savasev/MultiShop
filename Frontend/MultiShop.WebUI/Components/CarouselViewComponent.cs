using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Components;

public class CarouselViewComponent : ViewComponent
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public CarouselViewComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        var queryParams = new Dictionary<string, string?>
        {
            ["status"] = true.ToString().ToLower()
        };

        var url = QueryHelpers.AddQueryString("https://localhost:7070/api/featuresliders", queryParams);

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return Content(string.Empty);

        var jsonData = await response.Content.ReadAsStringAsync();
        var featureSliders = JsonConvert.DeserializeObject<List<FeatureSliderModel>>(jsonData);

        return View(featureSliders);
    }

    #endregion
}

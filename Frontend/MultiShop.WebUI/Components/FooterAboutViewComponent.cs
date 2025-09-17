using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Components;

public class FooterAboutViewComponent : ViewComponent
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public FooterAboutViewComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        var queryParams = new Dictionary<string, string>
        {
            ["settingCategoryId"] = "1", //footer about
        };

        var url = QueryHelpers.AddQueryString("https://localhost:7070/api/generalsettings", queryParams);

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return Content(string.Empty);

        var jsonData = await response.Content.ReadAsStringAsync();
        var generalSettings = JsonConvert.DeserializeObject<List<GeneralSettingModel>>(jsonData)
            ?? new List<GeneralSettingModel>();

        return View(generalSettings);
    }

    #endregion
}

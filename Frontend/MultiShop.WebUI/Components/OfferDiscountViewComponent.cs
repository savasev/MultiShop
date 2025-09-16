using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Components;

public class OfferDiscountViewComponent : ViewComponent
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public OfferDiscountViewComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/offerdiscounts");

        if (!response.IsSuccessStatusCode)
            return Content(string.Empty);

        var jsonData = await response.Content.ReadAsStringAsync();
        var offerDiscounts = JsonConvert.DeserializeObject<List<OfferDiscountModel>>(jsonData)
            ?? new List<OfferDiscountModel>();

        return View(offerDiscounts);
    }

    #endregion
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class FeatureSliderController : BaseAdminController
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public FeatureSliderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
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
    public async Task<IActionResult> FeatureSliderList()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/featuresliders");

        if (!response.IsSuccessStatusCode)
            return Json(new { data = new List<ResultFeatureSliderDto>() });

        var jsonData = await response.Content.ReadAsStringAsync();
        var featureSliders = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);

        return Json(new { data = featureSliders });
    }

    #endregion

    #region Create

    public IActionResult Create()
    {
        return View(new CreateFeatureSliderDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureSliderDto createFeatureSliderDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync("https://localhost:7070/api/featuresliders", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        return View(createFeatureSliderDto);
    }

    #endregion

    #region Edit

    public async Task<IActionResult> Edit(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"https://localhost:7070/api/featuresliders/{id}");

        if (!response.IsSuccessStatusCode)
            return RedirectToAction("List");

        var jsonData = await response.Content.ReadAsStringAsync();
        var editFeatureSliderDto = JsonConvert.DeserializeObject<EditFeatureSliderDto>(jsonData);

        return View(editFeatureSliderDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditFeatureSliderDto editFeatureSliderDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(editFeatureSliderDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync("https://localhost:7070/api/featuresliders", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        var errorMessage = await responseMessage.Content.ReadAsStringAsync();
        ModelState.AddModelError("", errorMessage);

        return View(editFeatureSliderDto);
    }

    #endregion

    #region Delete

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/featuresliders/{id}");

        if (responseMessage.IsSuccessStatusCode)
            return Json(new { success = true });

        return Json(new { success = false });
    }

    #endregion

    #endregion
}

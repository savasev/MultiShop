using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class FeatureController : BaseAdminController
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public FeatureController(IHttpClientFactory httpClientFactory)
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
    public async Task<IActionResult> FeatureList()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/features");

        if (!response.IsSuccessStatusCode)
            return Json(new { data = new List<ResultFeatureDto>() });

        var jsonData = await response.Content.ReadAsStringAsync();
        var features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

        return Json(new { data = features });
    }

    #endregion

    #region Create

    public IActionResult Create()
    {
        return View(new CreateFeatureDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createFeatureDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync("https://localhost:7070/api/features", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        return View(createFeatureDto);
    }

    #endregion

    #region Edit

    public async Task<IActionResult> Edit(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"https://localhost:7070/api/features/{id}");

        if (!response.IsSuccessStatusCode)
            return RedirectToAction("List");

        var jsonData = await response.Content.ReadAsStringAsync();
        var editFeatureDto = JsonConvert.DeserializeObject<EditFeatureDto>(jsonData);

        return View(editFeatureDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditFeatureDto editFeatureDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(editFeatureDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync("https://localhost:7070/api/features", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        var errorMessage = await responseMessage.Content.ReadAsStringAsync();
        ModelState.AddModelError("", errorMessage);

        return View(editFeatureDto);
    }

    #endregion

    #region Delete

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/features/{id}");

        if (responseMessage.IsSuccessStatusCode)
            return Json(new { success = true });

        return Json(new { success = false });
    }

    #endregion

    #endregion
}

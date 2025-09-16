using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SiteInfoDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class SiteInfoController : BaseAdminController
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public SiteInfoController(IHttpClientFactory httpClientFactory)
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
    public async Task<IActionResult> SiteInfoList()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/siteinfos");

        if (!response.IsSuccessStatusCode)
            return Json(new { data = new List<ResultSiteInfoDto>() });

        var jsonData = await response.Content.ReadAsStringAsync();
        var siteInfos = JsonConvert.DeserializeObject<List<ResultSiteInfoDto>>(jsonData);

        return Json(new { data = siteInfos });
    }

    #endregion

    #region Create

    public IActionResult Create()
    {
        return View(new CreateSiteInfoDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSiteInfoDto createSiteInfoDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createSiteInfoDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync("https://localhost:7070/api/siteinfos", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        return View(createSiteInfoDto);
    }

    #endregion

    #region Edit

    public async Task<IActionResult> Edit(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"https://localhost:7070/api/siteinfos/{id}");

        if (!response.IsSuccessStatusCode)
            return RedirectToAction("List");

        var jsonData = await response.Content.ReadAsStringAsync();
        var editSiteInfoDto = JsonConvert.DeserializeObject<EditSiteInfoDto>(jsonData);

        return View(editSiteInfoDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditSiteInfoDto editSiteInfoDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(editSiteInfoDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync("https://localhost:7070/api/siteinfos", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        var errorMessage = await responseMessage.Content.ReadAsStringAsync();
        ModelState.AddModelError("", errorMessage);

        return View(editSiteInfoDto);
    }

    #endregion

    #region Delete

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/siteinfos/{id}");

        if (responseMessage.IsSuccessStatusCode)
            return Json(new { success = true });

        return Json(new { success = false });
    }

    #endregion

    #endregion
}

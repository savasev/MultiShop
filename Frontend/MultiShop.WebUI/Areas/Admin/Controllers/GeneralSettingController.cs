using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.GeneralSettingDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class GeneralSettingController : BaseAdminController
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public GeneralSettingController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Utilities

    private async Task PrepareAvailableSettingCategoriesAsync(IList<SelectListItem> items, int? selectedValue = null)
    {
        if (items == null)
            throw new ArgumentNullException(nameof(items));

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7070/api/generalsettings/settingcategories");

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var settingCategories = JsonConvert.DeserializeObject<List<ResultSettingCategoryDto>>(jsonData);

            var categoryItems = settingCategories.Select(c => new SelectListItem
            {
                Text = c.Text,
                Value = c.Value.ToString(),
                Selected = c.Value == selectedValue
            }).ToList();

            ((List<SelectListItem>)items).AddRange(categoryItems);
        }

        items.Insert(0, new SelectListItem { Value = "", Text = "Select Category" });
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
    public async Task<IActionResult> GeneralSettingList()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/generalsettings");

        if (!response.IsSuccessStatusCode)
            return Json(new { data = new List<ResultGeneralSettingDto>() });

        var jsonData = await response.Content.ReadAsStringAsync();
        var generalSettings = JsonConvert.DeserializeObject<List<ResultGeneralSettingDto>>(jsonData);

        return Json(new { data = generalSettings });
    }

    #endregion

    #region Create

    public async Task<IActionResult> Create()
    {
        var createGeneralSettingDto = new CreateGeneralSettingDto();

        await PrepareAvailableSettingCategoriesAsync(createGeneralSettingDto.AvailableSettingCategories);

        return View(createGeneralSettingDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGeneralSettingDto createGeneralSettingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createGeneralSettingDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync("https://localhost:7070/api/generalsettings", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        await PrepareAvailableSettingCategoriesAsync(createGeneralSettingDto.AvailableSettingCategories);

        return View(createGeneralSettingDto);
    }

    #endregion

    #region Edit

    public async Task<IActionResult> Edit(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"https://localhost:7070/api/generalsettings/{id}");

        if (!response.IsSuccessStatusCode)
            return RedirectToAction("List");

        var jsonData = await response.Content.ReadAsStringAsync();
        var editGeneralSettingDto = JsonConvert.DeserializeObject<EditGeneralSettingDto>(jsonData);

        await PrepareAvailableSettingCategoriesAsync(editGeneralSettingDto.AvailableSettingCategories, editGeneralSettingDto.SettingCategoryId);

        return View(editGeneralSettingDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditGeneralSettingDto editGeneralSettingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(editGeneralSettingDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync("https://localhost:7070/api/generalsettings", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }

        var errorMessage = await responseMessage.Content.ReadAsStringAsync();
        ModelState.AddModelError("", errorMessage);

        await PrepareAvailableSettingCategoriesAsync(editGeneralSettingDto.AvailableSettingCategories, editGeneralSettingDto.SettingCategoryId);

        return View(editGeneralSettingDto);
    }

    #endregion

    #region Delete

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/generalsettings/{id}");

        if (responseMessage.IsSuccessStatusCode)
            return Json(new { success = true });

        return Json(new { success = false });
    }

    #endregion

    #endregion
}

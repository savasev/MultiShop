using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.GeneralSettingDtos;
using MultiShop.Catalog.Entities.Enums;
using MultiShop.Catalog.Services.GeneralSettingServices;

namespace MultiShop.Catalog.Controllers;

public class GeneralSettingsController : BaseApiController
{
    #region Fields

    private readonly IGeneralSettingService _generalSettingService;

    #endregion

    #region Ctor

    public GeneralSettingsController(IGeneralSettingService generalSettingService)
    {
        _generalSettingService = generalSettingService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetGeneralSettingList([FromQuery] GeneralSettingQueryDto generalSettingQueryDto)
    {
        var generalSettings = await _generalSettingService.GetAllGeneralSettingsAsync(settingCategoryId: generalSettingQueryDto.SettingCategoryId);

        return Ok(generalSettings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGeneralSettingById(string id)
    {
        var generalSetting = await _generalSettingService.GetGeneralSettingByIdAsync(id);

        return Ok(generalSetting);
    }

    [HttpGet("settingcategories")]
    public IActionResult GetCategories()
    {
        var categories = Enum.GetValues(typeof(SettingCategory)).Cast<SettingCategory>()
            .Select(category => new
            {
                Id = (int)category,
                Name = category.ToString()
            });

        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGeneralSetting(CreateGeneralSettingDto createGeneralSettingDto)
    {
        await _generalSettingService.CreateGeneralSettingAsync(createGeneralSettingDto);

        return Ok("Ayar başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGeneralSetting(UpdateGeneralSettingDto updateGeneralSettingDto)
    {
        await _generalSettingService.UpdateGeneralSettingAsync(updateGeneralSettingDto);

        return Ok("Ayar başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGeneralSetting(string id)
    {
        await _generalSettingService.DeleteGeneralSettingAsync(id);

        return Ok("Ayar başarıyla silindi.");
    }

    #endregion
}

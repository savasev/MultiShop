using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.SiteInfoDtos;
using MultiShop.Catalog.Services.SiteInfoServices;

namespace MultiShop.Catalog.Controllers;

public class SiteInfosController : ControllerBase
{
	#region Fields

	private readonly ISiteInfoService _siteInfoService;

    #endregion

    #region Ctor

    public SiteInfosController(ISiteInfoService siteInfoService)
    {
        _siteInfoService = siteInfoService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetSiteInfoList()
    {
        var siteInfos = await _siteInfoService.GetAllSiteInfosAsync();

        return Ok(siteInfos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSiteInfoById(string id)
    {
        var siteInfo = await _siteInfoService.GetSiteInfoByIdAsync(id);

        return Ok(siteInfo);
    }

    [HttpGet("siteinfobycategory/{category}")]
    public async Task<IActionResult> GetSiteInfoByCategory(string category)
    {
        var siteInfo = await _siteInfoService.GetSiteInfoByCategoryAsync(category);

        return Ok(siteInfo);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSiteInfo(CreateSiteInfoDto createSiteInfoDto)
    {
        await _siteInfoService.CreateSiteInfoAsync(createSiteInfoDto);

        return Ok("Site bilgisi başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSiteInfo(UpdateSiteInfoDto updateSiteInfoDto)
    {
        await _siteInfoService.UpdateSiteInfoAsync(updateSiteInfoDto);

        return Ok("Site bilgisi başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSiteInfo(string id)
    {
        await _siteInfoService.DeleteSiteInfoAsync(id);

        return Ok("Site bilgisi başarıyla silindi.");
    }

    #endregion
}

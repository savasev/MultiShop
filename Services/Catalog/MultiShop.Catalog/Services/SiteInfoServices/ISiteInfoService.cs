using MultiShop.Catalog.DTOs.SiteInfoDtos;

namespace MultiShop.Catalog.Services.SiteInfoServices;

public interface ISiteInfoService
{
    Task<List<ResultSiteInfoDto>> GetAllSiteInfosAsync();

    Task<GetByIdSiteInfoDto> GetSiteInfoByIdAsync(string id);

    Task<ResultSiteInfoDto> GetSiteInfoByCategoryAsync(string category);

    Task CreateSiteInfoAsync(CreateSiteInfoDto createSiteInfoDto);

    Task UpdateSiteInfoAsync(UpdateSiteInfoDto updateSiteInfoDto);

    Task DeleteSiteInfoAsync(string id);
}

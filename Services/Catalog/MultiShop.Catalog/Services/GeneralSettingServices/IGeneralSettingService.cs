using MultiShop.Catalog.DTOs.GeneralSettingDtos;

namespace MultiShop.Catalog.Services.GeneralSettingServices;

public interface IGeneralSettingService
{
    Task<List<ResultGeneralSettingDto>> GetAllGeneralSettingsAsync();

    Task<GetByIdGeneralSettingDto> GetGeneralSettingByIdAsync(string id);

    Task CreateGeneralSettingAsync(CreateGeneralSettingDto createGeneralSettingDto);

    Task UpdateGeneralSettingAsync(UpdateGeneralSettingDto updateGeneralSettingDto);

    Task DeleteGeneralSettingAsync(string id);
}

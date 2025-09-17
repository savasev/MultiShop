using Microsoft.AspNetCore.Mvc.Rendering;

namespace MultiShop.DtoLayer.CatalogDtos.GeneralSettingDtos;

public class CreateGeneralSettingDto
{
    #region Ctor

    public CreateGeneralSettingDto()
    {
        AvailableSettingCategories = new List<SelectListItem>();
    }

    #endregion

    #region Properties

    public int? SettingCategoryId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    public IList<SelectListItem> AvailableSettingCategories { get; set; }

    #endregion
}

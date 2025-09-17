using Microsoft.AspNetCore.Mvc.Rendering;

namespace MultiShop.DtoLayer.CatalogDtos.GeneralSettingDtos;

public class EditGeneralSettingDto
{
    #region Ctor

    public EditGeneralSettingDto()
    {
        AvailableSettingCategories = new List<SelectListItem>();
    }

    #endregion

    #region Properties

    public string GeneralSettingId { get; set; }

    public int CategoryId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    public IList<SelectListItem> AvailableSettingCategories { get; set; }

    #endregion
}

namespace MultiShop.Catalog.Dtos.GeneralSettingDtos;

public class UpdateGeneralSettingDto
{
    #region Properties

    public string GeneralSettingId { get; set; }

    public int? SettingCategoryId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    #endregion
}

namespace MultiShop.Catalog.Dtos.GeneralSettingDtos;

public class CreateGeneralSettingDto
{
    #region Properties

    public int? SettingCategoryId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    #endregion
}

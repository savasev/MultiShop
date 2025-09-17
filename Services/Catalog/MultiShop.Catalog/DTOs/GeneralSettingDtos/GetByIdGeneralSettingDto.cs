namespace MultiShop.Catalog.Dtos.GeneralSettingDtos;

public class GetByIdGeneralSettingDto
{
    #region Properties

    public string GeneralSettingId { get; set; }

    public int CategoryId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    #endregion
}

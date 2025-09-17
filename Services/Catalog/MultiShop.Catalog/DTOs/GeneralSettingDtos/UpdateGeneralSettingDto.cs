namespace MultiShop.Catalog.DTOs.GeneralSettingDtos;

public class UpdateGeneralSettingDto
{
    public string GeneralSettingId { get; set; }

    public int CategoryId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }
}

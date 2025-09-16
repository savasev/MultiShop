namespace MultiShop.DtoLayer.CatalogDtos.SiteInfoDtos;

public class CreateSiteInfoDto
{
    #region Properties

    public string Category { get; set; }

    public List<SiteInfoItemDto> Items { get; set; } = new();

    #endregion
}

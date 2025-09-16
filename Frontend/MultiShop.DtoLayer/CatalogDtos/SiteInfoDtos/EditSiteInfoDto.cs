namespace MultiShop.DtoLayer.CatalogDtos.SiteInfoDtos;

public class EditSiteInfoDto
{
    #region Properties

    public string SiteInfoId { get; set; }

    public string Category { get; set; }

    public List<SiteInfoItemDto> Items { get; set; } = new();

    #endregion
}

namespace MultiShop.DtoLayer.CatalogDtos.SiteInfoDtos;

public class ResultSiteInfoDto
{
    #region Properties

    public string SiteInfoId { get; set; }

    public string Category { get; set; }

    public List<SiteInfoItemDto> Items { get; set; } = new();

    #endregion
}

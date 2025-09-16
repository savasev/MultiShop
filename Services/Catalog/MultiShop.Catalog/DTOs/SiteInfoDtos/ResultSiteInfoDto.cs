namespace MultiShop.Catalog.DTOs.SiteInfoDtos;

public class ResultSiteInfoDto
{
    public string SiteInfoId { get; set; }

    public string Category { get; set; }

    public List<SiteInfoItemDto> Items { get; set; } = new();
}

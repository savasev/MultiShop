namespace MultiShop.Catalog.DTOs.SiteInfoDtos;

public class GetByIdSiteInfoDto
{
    public string SiteInfoId { get; set; }

    public string Category { get; set; }

    public List<SiteInfoItemDto> Items { get; set; } = new();
}

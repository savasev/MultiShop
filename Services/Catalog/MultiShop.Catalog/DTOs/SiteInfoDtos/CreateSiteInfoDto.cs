namespace MultiShop.Catalog.DTOs.SiteInfoDtos;

public class CreateSiteInfoDto
{
    public string Category { get; set; }

    public List<SiteInfoItemDto> Items { get; set; } = new();
}

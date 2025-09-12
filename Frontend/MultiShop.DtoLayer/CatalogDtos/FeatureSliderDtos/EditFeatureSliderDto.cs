namespace MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

public class EditFeatureSliderDto
{
    #region Properties

    public string FeatureSliderId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public int DisplayOrder { get; set; }

    public bool Status { get; set; }

    #endregion
}

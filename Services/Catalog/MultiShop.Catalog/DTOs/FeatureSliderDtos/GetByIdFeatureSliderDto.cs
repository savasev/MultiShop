namespace MultiShop.Catalog.Dtos.FeatureSliderDtos;

public class GetByIdFeatureSliderDto
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

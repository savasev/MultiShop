using Microsoft.AspNetCore.Mvc.Rendering;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos;

public class EditProductDto
{
    #region Ctor

    public EditProductDto()
    {
        AvailableCategories = new List<SelectListItem>();
    }

    #endregion

    #region Properties

    public string ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal ProductPrice { get; set; }

    public int ProductStock { get; set; }

    public string ProductImageUrl { get; set; }

    public string ProductDescription { get; set; }

    public string CategoryId { get; set; }

    public IList<SelectListItem> AvailableCategories { get; set; }

    #endregion
}

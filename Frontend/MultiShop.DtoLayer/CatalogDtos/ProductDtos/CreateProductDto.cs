using Microsoft.AspNetCore.Mvc.Rendering;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos;

public class CreateProductDto
{
    #region Properties

    public string ProductName { get; set; }

    public decimal ProductPrice { get; set; }

    public int ProductStock { get; set; }

    public string ProductImageUrl { get; set; }

    public string ProductDescription { get; set; }

    public string CategoryId { get; set; }

    public List<SelectListItem> AvailableCategories { get; set; }

    #endregion
}

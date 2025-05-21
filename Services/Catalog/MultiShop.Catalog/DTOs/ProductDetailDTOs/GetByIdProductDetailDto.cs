using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DTOs.ProductDetailDTOs;

public class GetByIdProductDetailDto
{
    public int ProductDetailId { get; set; }

    public string ProductId { get; set; }

    public string ProductDescription { get; set; }

    public string ProductInfo { get; set; }
}

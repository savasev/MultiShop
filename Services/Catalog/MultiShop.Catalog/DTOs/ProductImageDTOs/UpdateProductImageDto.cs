﻿namespace MultiShop.Catalog.DTOs.ProductImageDTOs;

public class UpdateProductImageDto
{
    public int ProductImageId { get; set; }

    public string ProductId { get; set; }

    public string Image1 { get; set; }

    public string Image2 { get; set; }

    public string Image3 { get; set; }
}

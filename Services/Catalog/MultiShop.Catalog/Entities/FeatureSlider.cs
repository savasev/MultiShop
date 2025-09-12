﻿using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class FeatureSlider
{
    [BsonId]
    public string FeatureSliderId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public bool Status { get; set; }
}

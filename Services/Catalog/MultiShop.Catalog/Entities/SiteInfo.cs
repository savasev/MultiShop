using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class SiteInfo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string SiteInfoId { get; set; }

    public string Category { get; set; }

    public List<SiteInfoItem> Items { get; set; } = new();

    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class ProductImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int ProductImageId { get; set; }

    public string ProductId { get; set; }

    public string Image1 { get; set; }

    public string Image2 { get; set; }

    public string Image3 { get; set; }

    [BsonIgnore]
    public Product Product { get; set; }
}

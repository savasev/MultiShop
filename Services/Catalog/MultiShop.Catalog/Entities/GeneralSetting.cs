using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class GeneralSetting
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string GeneralSettingId { get; set; }

    public int? SettingCategoryId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }
}

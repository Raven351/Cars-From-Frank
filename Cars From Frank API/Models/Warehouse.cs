using MongoDB.Bson.Serialization.Attributes;

namespace Cars_From_Frank_API.Models
{
    public class Warehouse
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public int? Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("location")]
        public Location WarehouseLocation { get; set; }
        [BsonElement("cars")]
        public Cars CarsInWarehouse { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;

namespace Cars_From_Frank_API.Models
{
    /// <summary>
    /// Warehouse model. Top model in database.
    /// </summary>
    public class Warehouse
    {
        [BsonId]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location")]
        public Location WarehouseLocation { get; set; }

        [BsonElement("cars")]
        public Cars CarsInWarehouse { get; set; }
    }
}

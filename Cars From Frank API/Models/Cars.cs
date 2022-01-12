using MongoDB.Bson.Serialization.Attributes;

namespace Cars_From_Frank_API.Models
{
    /// <summary>
    /// Model for "cars in warehouse"
    /// </summary>
    public class Cars
    {
        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("vehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}
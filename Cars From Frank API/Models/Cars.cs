using MongoDB.Bson.Serialization.Attributes;

namespace Cars_From_Frank_API.Models
{
    public class Cars
    {
        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("vehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}
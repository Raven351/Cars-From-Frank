using MongoDB.Bson.Serialization.Attributes;

namespace Cars_From_Frank_API.Models
{
    /// <summary>
    /// Location model
    /// </summary>
    public class Location
    {
        [BsonElement("lat")]
        public double Latitude { get; set; }

        [BsonElement("long")]
        public double Longitude { get; set; }
    }
}
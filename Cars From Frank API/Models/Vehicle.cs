﻿using MongoDB.Bson.Serialization.Attributes;

namespace Cars_From_Frank_API.Models
{
    public class Vehicle
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public int Id { get; set; }

        [BsonElement("make")]
        public string Make { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("year_model")]
        public int YearModel { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("licensed")]
        public bool IsLicensed { get; set; }

        [BsonElement("date_added")]
        public DateOnly DateAdded { get; set; }

    }
}
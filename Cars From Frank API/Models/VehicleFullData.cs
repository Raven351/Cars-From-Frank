using MongoDB.Bson.Serialization.Attributes;

namespace Cars_From_Frank_API.Models
{
    /// <summary>
    /// Vehicle class expanded with addtional data found in parent paths in json
    /// </summary>
    public class VehicleFullData : Vehicle
    {
        [BsonElement("garage_name")]
        public string? GarageName { get; set; }

        [BsonElement("warehouse_location")]
        public Location? Location { get; set; }

        [BsonElement("cars_location")]
        public string? CarsLocation { get; set; }

        public VehicleFullData (Vehicle vehicle) : base()
        {
            this.Id = vehicle.Id;
            this.Make = vehicle.Make;
            this.Model = vehicle.Model;
            this.DateAdded = vehicle.DateAdded;
            this.IsLicensed = vehicle.IsLicensed;
            this.YearModel = vehicle.YearModel;
            this.Price = vehicle.Price;
        }
    }
}

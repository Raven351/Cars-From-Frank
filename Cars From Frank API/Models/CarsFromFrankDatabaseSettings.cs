namespace Cars_From_Frank_API.Models
{
    /// <summary>
    /// Database settings model class
    /// </summary>
    public class CarsFromFrankDatabaseSettings
    {
        /// <summary>
        /// MongoDB connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Name of the databse
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Name of the collection from inside of the databse
        /// </summary>
        public string CollectionName { get; set; }
    }
}

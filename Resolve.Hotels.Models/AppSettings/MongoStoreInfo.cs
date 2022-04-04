namespace Resolve.Hotels.Models.AppSettings
{
    public class MongoStoreInfo
    {
        public string ConnectionString { get; set; }
        public string PartitionName { get; set; }
        public string DatabaseName { get; set; }
    }
}
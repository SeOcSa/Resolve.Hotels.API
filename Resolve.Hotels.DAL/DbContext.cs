using MongoDB.Driver;

namespace Resolve.Hotels.DAL
{
    public class DbContext
    {
        public readonly IMongoDatabase Db;
        public DbContext(string connectionString)
        {
            Db = new MongoClient(connectionString).GetDatabase("resolve-db");
        }
    }
}
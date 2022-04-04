using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Resolve.Hotels.DAL.Repositories.Interfaces;
using Resolve.Hotels.Models.AppSettings;

namespace Resolve.Hotels.DAL.Repositories.Concrete
{
    public class MongoDocumentStore : IDocumentStore
    {
        private readonly GridFSBucket gridFsBucket;

        public MongoDocumentStore(MongoStoreInfo mongoStoreInfo)
        {
            var client = new MongoClient(mongoStoreInfo.ConnectionString);

            var database = client.GetDatabase(mongoStoreInfo.DatabaseName);

            gridFsBucket = new GridFSBucket(database, new GridFSBucketOptions
            {
                BucketName = mongoStoreInfo.PartitionName,
                ChunkSizeBytes = 1048576,
                WriteConcern = WriteConcern.WMajority,
                ReadPreference = ReadPreference.Primary
            });
        }
        public async Task<string> UploadFile(byte[] file, string hotelName)
        {
            var options = new GridFSUploadOptions
            {
                Metadata = new BsonDocument()
            };

            options.Metadata.Add(new BsonElement("statusChangeDate", new BsonDateTime(DateTime.Now)));

            return (await gridFsBucket.UploadFromBytesAsync(hotelName, file, options)).ToString();
        }

        public async Task<byte[]> DownloadFile(string storeId)
        {
            return await gridFsBucket.DownloadAsBytesAsync(ObjectId.Parse(storeId));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Resolve.Hotels.DAL.Repositories.Interfaces;
using Resolve.Hotels.Models.Enitities;

namespace Resolve.Hotels.DAL.Repositories.Concrete
{
    public class GenericRepository<T>: IGenericRepository<T>, IDisposable where T: Entity
    {
        private readonly IMongoDatabase? _db;

        public GenericRepository(DbContext dbContext)
        {
            _db = dbContext.Db;
        }
        
        private IMongoQueryable<T> GetCollectionAsQueryable<T>()
        {
            return _db.GetCollection<T>(typeof(T).Name.ToLower()).AsQueryable();
        }
        
        private IMongoCollection<T>? GetCollection<T>()
        {
            return _db.GetCollection<T>(typeof(T).Name.ToLower());
        }

        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetCollectionAsQueryable<T>().ToListAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            return await GetCollectionAsQueryable<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(T entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            await GetCollection<T>().InsertOneAsync(entity);
        }

        public void Dispose()
        {
        }
    }
}
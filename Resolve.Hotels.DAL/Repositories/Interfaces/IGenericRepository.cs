using System.Collections.Generic;
using System.Threading.Tasks;
using Resolve.Hotels.Models.Enitities;

namespace Resolve.Hotels.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(string id);
        Task Add(T entity);
    }
}
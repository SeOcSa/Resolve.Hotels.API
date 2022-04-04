using System.Collections.Generic;
using System.Threading.Tasks;
using Resolve.Hotels.Models.Enitities;
using Resolve.Hotels.Models.ViewModels;

namespace Resolve.Hotels.API.Services
{
    public interface IGenericService<VM, E> where VM: IGenericViewModel where  E: Entity
    {
        Task<IEnumerable<VM>> GetAllAsync();
        Task<VM> GetAsync(string id);
        Task Add(VM viewModel);
    }
}
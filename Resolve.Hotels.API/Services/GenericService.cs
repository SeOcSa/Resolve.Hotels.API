using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resolve.Hotels.DAL.Repositories.Interfaces;
using Resolve.Hotels.Models.Enitities;
using Resolve.Hotels.Models.Helpers;
using Resolve.Hotels.Models.ViewModels;

namespace Resolve.Hotels.API.Services
{
    public class GenericService<VM, E>: IGenericService<VM, E>, IDisposable where VM: IGenericViewModel where E: Entity
    {
        private IGenericRepository<E> _repository;
        public GenericService(IGenericRepository<E> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VM>> GetAllAsync()
        {
            var customMapper = new CustomMapper<VM, E>();
            return (await _repository.GetAllAsync()).Select(x => customMapper.MapToViewModel(x));
        }

        public async Task<VM> GetAsync(string id)
        {
            var customMapper = new CustomMapper<VM, E>();
            return customMapper.MapToViewModel(await _repository.GetAsync(id));
        }

        public async Task Add(VM viewModel)
        {
            var entity = new CustomMapper<VM, E>().MapToEntity(viewModel);
            await _repository.Add(entity);
        }

        public void Dispose()
        {
        }
    }
}
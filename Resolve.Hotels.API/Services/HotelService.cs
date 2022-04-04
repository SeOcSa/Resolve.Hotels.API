using System.Threading.Tasks;
using Resolve.Hotels.DAL.Repositories.Interfaces;
using Resolve.Hotels.Models;
using Resolve.Hotels.Models.ViewModels;

namespace Resolve.Hotels.API.Services
{
    public class HotelService: GenericService<HotelViewModel, HotelEntity>, IHotelServices
    {
        private IDocumentStore _documentStore;
        public HotelService(IHotelRepository repository, IDocumentStore documentStore) : base(repository)
        {
            _documentStore = documentStore;
        }

        public async Task Add(HotelViewModel viewModel)
        {
            await _documentStore.UploadFile(viewModel.Image, viewModel.Name);
            await base.Add(viewModel);
        }
    }
}
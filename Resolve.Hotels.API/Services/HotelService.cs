using Resolve.Hotels.DAL.Repositories.Interfaces;
using Resolve.Hotels.Models;
using Resolve.Hotels.Models.ViewModels;

namespace Resolve.Hotels.API.Services
{
    public class HotelService: GenericService<HotelViewModel, HotelEntity>, IHotelServices
    {
        public HotelService(IHotelRepository repository) : base(repository)
        {
        }
    }
}
using Resolve.Hotels.Models;

namespace Resolve.Hotels.DAL.Repositories.Interfaces
{
    public interface IHotelRepository: IGenericRepository<HotelEntity>
    {
        void AddToFavorite(string userId, string hotelId);
    }
}
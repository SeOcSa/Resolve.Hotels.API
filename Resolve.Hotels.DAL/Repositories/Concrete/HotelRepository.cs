using Resolve.Hotels.DAL.Repositories.Interfaces;
using Resolve.Hotels.Models;

namespace Resolve.Hotels.DAL.Repositories.Concrete
{
    public class HotelRepository: GenericRepository<HotelEntity>, IHotelRepository
    {
        public HotelRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void AddToFavorite(string userId, string hotelId)
        {
            throw new System.NotImplementedException();
        }
    }
}
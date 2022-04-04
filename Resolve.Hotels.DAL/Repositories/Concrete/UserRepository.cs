using Resolve.Hotels.DAL.Repositories.Interfaces;
using Resolve.Hotels.Models.Enitities;

namespace Resolve.Hotels.DAL.Repositories.Concrete
{
    public class UserRepository: GenericRepository<UserFavoritesEntity>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
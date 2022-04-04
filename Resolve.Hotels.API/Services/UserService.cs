using Resolve.Hotels.DAL.Repositories.Interfaces;
using Resolve.Hotels.Models.Enitities;
using Resolve.Hotels.Models.ViewModels;

namespace Resolve.Hotels.API.Services
{
    public class UserService: GenericService<UserFavoriteViewModel, UserFavoritesEntity>
    {
        public UserService(IGenericRepository<UserFavoritesEntity> repository) : base(repository)
        {
        }
    }
}
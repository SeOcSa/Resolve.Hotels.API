using Resolve.Hotels.Models.Enitities;
using Resolve.Hotels.Models.ViewModels;

namespace Resolve.Hotels.API.Services
{
    public interface IUserService : IGenericService<UserFavoriteViewModel, UserFavoritesEntity>
    {
        
    }
}
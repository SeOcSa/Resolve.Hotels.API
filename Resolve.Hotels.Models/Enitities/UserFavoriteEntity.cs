namespace Resolve.Hotels.Models.Enitities
{
    public class UserFavoritesEntity: Entity
    {
        public string UserId { get; set; }
        public string HotelId { get; set; }
    }
}
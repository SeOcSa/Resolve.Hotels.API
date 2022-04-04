using Resolve.Hotels.Models.Enitities;

namespace Resolve.Hotels.Models
{
    public class HotelEntity : Entity
    {
        public string Name { get; set; }
        public string StoreId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stars { get; set; }
    }
}
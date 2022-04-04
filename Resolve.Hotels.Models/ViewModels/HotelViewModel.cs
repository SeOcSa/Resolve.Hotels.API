namespace Resolve.Hotels.Models.ViewModels
{
    public class HotelViewModel : IGenericViewModel
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stars { get; set; }
    }
}
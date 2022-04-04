using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resolve.Hotels.API.Services;
using Resolve.Hotels.Models;
using Resolve.Hotels.Models.ViewModels;

namespace Resolve.Hotels.API.Controllers
{
    [Route("api/hotel")]
    public class HotelController: BaseController<HotelViewModel, HotelEntity>
    {
        public HotelController(IHotelServices service) : base(service)
        {
        }
        
        [Route("addToFavorites")]
        [HttpPost]
        public async Task<IActionResult> AddToFavorites()
        {
            return Ok();
        }
    }
}
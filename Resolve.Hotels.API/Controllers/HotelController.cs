using System;
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
        private readonly IUserService _userService;
        public HotelController(IHotelServices service, IUserService userService) : base(service)
        {
            _userService = userService;
        }
        
        [Route("addToFavorites")]
        [HttpPost]
        public async Task<IActionResult> AddToFavorites(UserFavoriteViewModel viewModel)
        {
            try
            {
                await _userService.Add(viewModel);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
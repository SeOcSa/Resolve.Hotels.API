using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resolve.Hotels.API.Services;
using Resolve.Hotels.Models.Enitities;
using Resolve.Hotels.Models.ViewModels;

namespace Resolve.Hotels.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class BaseController<VM, E> : ControllerBase where VM : IGenericViewModel where  E: Entity
    {
        private readonly IGenericService<VM, E> _service;
        public BaseController(IGenericService<VM, E> service)
        {
            _service = service;
        }
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> Add(VM viewModel)
        {
            try
            {
                await _service.Add(viewModel);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e}");
            }
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var hotels = await _service.GetAllAsync();
                return Ok(hotels);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(400, "Bad request");
            }
            
            try
            {
                var hotel = await _service.GetAsync(id);
                return hotel == null ? StatusCode(404, "Not found") : Ok(hotel);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
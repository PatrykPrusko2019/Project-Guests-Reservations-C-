using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class GuestsController : ControllerBase
    {

        private readonly IGuestService _guestService;
        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var guests = _guestService.GetAllGuests();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var guest = _guestService.GetGuestById(id);
            if(guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }
    }
}

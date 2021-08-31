using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        [SwaggerOperation(Summary = "Retrieves all guests")]
        [HttpGet]
        public IActionResult Get()
        {
            var guests = _guestService.GetAllGuests();
            return Ok(guests.ToList());
        }

        [SwaggerOperation(Summary = "Retrieves a specific guest by unique id")]
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

        [SwaggerOperation(Summary = "Create a new guest")]
        [HttpPost]
        public IActionResult Create(CreateGuestDto newGuest) 
        {
            var guest = _guestService.AddNewGuest(newGuest);
            return Created($"api/guests/{guest.Id_Guest}", guest);

        }

        [SwaggerOperation(Summary = "Update a existing guest")]
        [HttpPut]
        public IActionResult Update (UpdateGuestDto updateGuest)
        {
            _guestService.UpdateGuest(updateGuest);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific guest")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _guestService.DeleteGuest(id);
            return NoContent();
        }

        [SwaggerOperation(Summary = "metoda zrzucająca listę wszystkich gości o imieniu Piotr z miasta Wrocław lub bez miasta")]
        [HttpGet("/GuestsAllNamePiter")]
        public IActionResult GetAllGuestsByNamePiterAndCityWroclaw()
        {
            var guests = _guestService.GetAllGuestByNamePiter();
            

            return Ok(guests.ToList());
        }
       

    }
}

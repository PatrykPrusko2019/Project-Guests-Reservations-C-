using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsGuestsController : ControllerBase
    {

        private readonly IReservationsGuestsService _reservationsGuestsService;
        public ReservationsGuestsController(IReservationsGuestsService reservationsGuestsService)
        {
            _reservationsGuestsService = reservationsGuestsService;
        }

        [SwaggerOperation(Summary = "Retrieves all reservations and guests -> metoda zrzucająca wszystkie rezerwacje (bez parametru)")]
        [HttpGet]
        public IActionResult Get()
        {
            var reservationsGuests = _reservationsGuestsService.GetAllReservationsGuests();
            return Ok(reservationsGuests.ToList());
        }


        [SwaggerOperation(Summary = "Retrieves a specific reservationsGuests by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reservationsGuests = _reservationsGuestsService.GetReservationGuestById(id);
            if (reservationsGuests == null)
            {
                return NotFound();
            }

            return Ok(reservationsGuests);
        }

        [SwaggerOperation(Summary = "Create a new reservationsGuests -> metodą zapisująca rezerwację wraz z gośćmi na podstawie przekazanych parametrów")]
        [HttpPost]
        public IActionResult Create(CreateReservationsGuestsDto newReservationsGuests)
        {
            var reservationsGuests = _reservationsGuestsService.AddNewReservationsGuests(newReservationsGuests);
            return Created($"api/reservations/{reservationsGuests.Id_Reservation_Guest}", reservationsGuests);

        }

        [SwaggerOperation(Summary = "Update a existing reservationsGuests")]
        [HttpPut]
        public IActionResult Update(UpdateReservationsGuestsDto updateReservationsGuests)
        {
            _reservationsGuestsService.UpdateReservationsGuests(updateReservationsGuests);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific reservationsGuests")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reservationsGuestsService.DeleteReservationsGuests(id);
            return NoContent();
        }

    }
}

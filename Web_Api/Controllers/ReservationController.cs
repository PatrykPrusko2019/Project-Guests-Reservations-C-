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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [SwaggerOperation(Summary = "Retrieves all reservations -> metoda zrzucająca wszystkie rezerwacje (bez parametru)")]
        [HttpGet]
        public IActionResult Get()
        {
            var reservations = _reservationService.GetAllReservations();
            return Ok(reservations.ToList());
        }


        [SwaggerOperation(Summary = "Retrieves a specific reservation by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reservation = _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [SwaggerOperation(Summary = "Create a new reservation")]
        [HttpPost]
        public IActionResult Create(CreateReservationDto newReservation)
        {
            var reservation = _reservationService.AddNewReservation(newReservation);
            return Created($"api/reservations/{reservation.Id_Reservation}", reservation);

        }

        [SwaggerOperation(Summary = "Update a existing reservation")]
        [HttpPut]
        public IActionResult Update(UpdateReservationDto updateReservation)
        {
            _reservationService.UpdateReservation(updateReservation);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific reservation")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reservationService.DeleteReservation(id);
            return NoContent();
        }

    }
}

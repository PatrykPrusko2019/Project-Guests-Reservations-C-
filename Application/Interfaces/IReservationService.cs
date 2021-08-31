using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReservationService
    {
        IEnumerable<ReservationDto> GetAllReservations();

        ReservationDto GetReservationById(int id);

       ReservationDto AddNewReservation(CreateReservationDto newReservation);

       void UpdateReservation(UpdateReservationDto updateReservation);

       void DeleteReservation(int id);
    }
}

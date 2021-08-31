using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReservationsGuestsService
    {
        IEnumerable<ReservationsGuestsDto> GetAllReservationsGuests();

        ReservationsGuestsDto GetReservationGuestById(int id);

        ReservationsGuestsDto AddNewReservationsGuests(CreateReservationsGuestsDto newReservationsGuests);

        void UpdateReservationsGuests(UpdateReservationsGuestsDto updateReservationsGuests);

        void DeleteReservationsGuests(int id);
    }
}

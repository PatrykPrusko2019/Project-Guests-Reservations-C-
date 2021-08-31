using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReservationsGuestsRepository
    {
        IEnumerable<ReservationsGuests> GetAll();

        ReservationsGuests GetById(int id);

        ReservationsGuests Add(ReservationsGuests reservationsGuests);

        void Update(ReservationsGuests reservationsGuests);

        void Delete(ReservationsGuests reservationsGuests);
    }
}

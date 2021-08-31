using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();

        Reservation GetById(int id);

        Reservation Add(Reservation reservation);

        void Update(Reservation reservation);

        void Delete(Reservation reservation);
    }
}
